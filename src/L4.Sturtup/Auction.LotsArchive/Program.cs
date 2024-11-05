using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Presentation.Initialization;
using Auction.Common.Presentation.Mapping;
using Auction.Common.Presentation.Validation;
using Auction.LotsArchive;
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
using Auction.LotsArchive.Infrastructure.EntityFramework;
using Auction.LotsArchive.Infrastructure.Repositories.EntityFramework;
using Auction.LotsArchive.Presentation.Validation.Archiving;
using Auction.LotsArchive.Presentation.WebApi.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(dbConnectionString))
{
    throw new InvalidOperationException("Connection string for ApplicationDbContext is not configured.");
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
        Title = "Auction Lots Archive API",
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

builder.Services.AddHealthChecks();

builder.Services.AddAutoMapper(
    typeof(ApplicationMappingProfile),
    typeof(CommonPresentationMappingProfile),
    typeof(PresentationMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("health");

app.UseAuthorization();

app.MapControllers();

await app.MigrateAsync<ApplicationDbContext>();

if (app.Environment.IsDevelopment())
{
    await app.InitAsync<DbInitializer>();
}


app.Run();
