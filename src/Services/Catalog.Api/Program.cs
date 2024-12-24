var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database") ?? 
                      throw new InvalidOperationException("There's no connection string"));
}).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

await app.RunAsync();