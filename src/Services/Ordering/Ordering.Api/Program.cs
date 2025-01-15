WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
WebApplication app = builder.Build();

await app.RunAsync();