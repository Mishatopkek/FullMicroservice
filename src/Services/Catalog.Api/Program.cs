using System.Reflection;

Assembly catalogApiAssembly = typeof(Program).Assembly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(catalogApiAssembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(catalogApiAssembly);

builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database") ??
                      throw new InvalidOperationException("There's no connection string"));
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment()) builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();

await app.RunAsync();