using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Infrastructure.DbInitialization;
using Auction.Common.Presentation.Mapping;
using Auction.Common.Presentation.Validation;
using Auction.LotsArchive.Application.L1.Models.Buyers;
using Auction.LotsArchive.Application.L1.Models.Copying;
using Auction.LotsArchive.Application.L1.Models.Sellers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Buyers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Copying;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Sellers;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Application.L3.Logic.Handlers.Archiving;
using Auction.LotsArchive.Application.L3.Logic.Handlers.Buyers;
using Auction.LotsArchive.Application.L3.Logic.Handlers.Copying;
using Auction.LotsArchive.Application.L3.Logic.Handlers.Persons;
using Auction.LotsArchive.Application.L3.Logic.Handlers.Sellers;
using Auction.LotsArchive.Application.L3.Logic.Mapping;
using Auction.LotsArchive.Infrastructure.DbInitialization;
using Auction.LotsArchive.Infrastructure.EntityFramework;
using Auction.LotsArchive.Infrastructure.Repositories.EntityFramework;
using Auction.LotsArchive.Presentation.GrpcApi.Services;
using Auction.LotsArchive.Presentation.MassTransit.Lots;
using Auction.LotsArchive.Presentation.MassTransit.Persons;
using Auction.LotsArchive.Presentation.Validation.Archiving;
using Auction.LotsArchive.Presentation.WebApi.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Otus.QueueDto.Lot;
using Otus.QueueDto.User;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddConsole();

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(dbConnectionString))
{
    throw new InvalidOperationException("Connection string for ApplicationDbContext is not configured.");
}

var rmqConnectionString = builder.Configuration.GetConnectionString("RabbitMqConfig");
if (string.IsNullOrEmpty(rmqConnectionString))
{
    throw new InvalidOperationException("Connection string for RabbitMQ is not configured.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        dbConnectionString,
        opt => opt.MigrationsAssembly("Auction.LotsArchive.Infrastructure.EntityFramework")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Auction Archive API",
        Description = "API of the lot archive microservice for viewing information on completed lots"
    }));

builder.Services.AddValidatorsFromAssemblyContaining<CreatePersonCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LotModelValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();
builder.Services.AddScoped<IBuyersRepository, BuyersRepository>();
builder.Services.AddScoped<ISellersRepository, SellersRepository>();
builder.Services.AddScoped<ILotsRepository, LotsRepository>();
builder.Services.AddScoped<IRepurchasedLotsRepository, RepurchasedLotsRepository>();
builder.Services.AddScoped<IWithdrawnLotsRepository, WithdrawnLotsRepository>();

builder.Services.AddTransient<ICommandHandler<CreatePersonCommand>, CreatePersonHandler>();
builder.Services.AddTransient<ICommandHandler<DeletePersonCommand>, DeletePersonHandler>();
builder.Services.AddTransient<ICommandHandler<IsPersonCommand>, IsPersonHandler>();

builder.Services.AddTransient<ICommandHandler<AddRepurchasedLotCommand>, AddRepurchasedLotHandler>();
builder.Services.AddTransient<ICommandHandler<AddUnpurchasedLotCommand>, AddUnpurchasedLotHandler>();
builder.Services.AddTransient<ICommandHandler<AddWithdrawnLotCommand>, AddWithdrawnLotHandler>();

builder.Services.AddTransient<IQueryHandler<GetLotCopyQuery, LotCopyModel>, GetLotCopyHandler>();

builder.Services.AddTransient<IQueryPageHandler<GetBuyerBoughtLotsQuery, BoughtLotModel>, GetBuyerBoughtLotsHandler>();

builder.Services.AddTransient<IQueryPageHandler<GetSellerSoldLotsQuery, SoldLotModel>, GetSellerSoldLotsHandler>();
builder.Services.AddTransient<IQueryPageHandler<GetSellerUnpurchasedLotsQuery, UnpurchasedLotModel>, GetSellerUnpurchasedLotsHandler>();
builder.Services.AddTransient<IQueryPageHandler<GetSellerWithdrawnLotsQuery, WithdrawnLotModel>, GetSellerWithdrawnLotsHandler>();

builder.Services.AddTransient<DbInitializer>();

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString)
    .AddRabbitMQ(rabbitConnectionString: rmqConnectionString)
    .AddDbContextCheck<ApplicationDbContext>();

builder.Services.AddAutoMapper(
    typeof(ApplicationMappingProfile),
    typeof(CommonWebApiMappingProfile),
    typeof(WebApiMappingProfile));

builder.Services.AddGrpc();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateUserConsumer>();
    x.AddConsumer<CancelLotConsumer>();
    x.AddConsumer<WonLotConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(rmqConnectionString));

        cfg.ReceiveEndpoint($"{nameof(CreateUserEvent)}.Archive", e =>
        {
            e.ConfigureConsumer<CreateUserConsumer>(context);
        });
        cfg.ReceiveEndpoint($"{nameof(CancelLotEvent)}.Archive", e =>
        {
            e.ConfigureConsumer<CancelLotConsumer>(context);
        });
        cfg.ReceiveEndpoint($"{nameof(WonLotEvent)}.Archive", e =>
        {
            e.ConfigureConsumer<WonLotConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
        cfg.UseMessageRetry(r =>
        {
            r.Interval(3, TimeSpan.FromSeconds(10));
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapGrpcService<CopyingService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseAuthorization();

app.MapControllers();

await app.MigrateAsync<ApplicationDbContext>();

if (app.Environment.IsDevelopment())
{
    await app.InitAsync<DbInitializer>();
}

app.Run();
