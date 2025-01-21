using Ordering.Api;
using Ordering.Application;
using Ordering.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

WebApplication app = builder.Build();

await app.RunAsync();