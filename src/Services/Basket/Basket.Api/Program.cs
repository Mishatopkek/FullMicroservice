using System.Reflection;
using Microsoft.Extensions.Caching.Distributed;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Assembly assembly = typeof(Program).Assembly;

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database") ??
                      throw new InvalidOperationException("There's no connection string"));
    config.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddScoped<IBasketRepository>(provider =>
{
    BasketRepository basketRepository = provider.GetRequiredService<BasketRepository>();
    return new CachedBasketRepository(basketRepository, provider.GetRequiredService<IDistributedCache>());
});

builder.Services.AddScoped<IBasketRepository, CachedBasketRepository>();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

WebApplication app = builder.Build();

app.MapCarter();
app.UseExceptionHandler();

await app.RunAsync();