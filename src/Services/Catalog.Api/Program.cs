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

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception == null) return;

        ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = exception.Message,
            Detail = exception.StackTrace
        };

        ILogger<Program> logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, exception.Message);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

await app.RunAsync();