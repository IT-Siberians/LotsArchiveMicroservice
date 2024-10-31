using Auction.Common.Application.Commands;
using Auction.Common.Application.Handlers.Abstractions;
using Auction.Common.Presentation.Initialization;
using Auction.Common.Presentation.Mapping;
using Auction.Common.Presentation.Validation;
using Auction.LotsArchiveMicroservice.Application.Commands.Archiving;
using Auction.LotsArchiveMicroservice.Application.Commands.Buyers;
using Auction.LotsArchiveMicroservice.Application.Commands.Copying;
using Auction.LotsArchiveMicroservice.Application.Commands.Sellers;
using Auction.LotsArchiveMicroservice.Application.Handlers.Archiving;
using Auction.LotsArchiveMicroservice.Application.Handlers.Buyers;
using Auction.LotsArchiveMicroservice.Application.Handlers.Copying;
using Auction.LotsArchiveMicroservice.Application.Handlers.Persons;
using Auction.LotsArchiveMicroservice.Application.Handlers.Sellers;
using Auction.LotsArchiveMicroservice.Application.Mapping;
using Auction.LotsArchiveMicroservice.Application.Models.Buyers;
using Auction.LotsArchiveMicroservice.Application.Models.Copying;
using Auction.LotsArchiveMicroservice.Application.Models.Sellers;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.EntityFramework;
using Auction.LotsArchiveMicroservice.Presentation.WebApi.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

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
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
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

app.UseAuthorization();

app.MapControllers();

await app.MigrateAsync<ApplicationDbContext>();

app.Run();
