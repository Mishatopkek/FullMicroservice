using System.Reflection;
using BuildingBlocks.Behaviours;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

Assembly? catalogApiAssembly = typeof(Program).Assembly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(catalogApiAssembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(catalogApiAssembly);

builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database") ??
                      throw new InvalidOperationException("There's no connection string"));
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();

await app.RunAsync();