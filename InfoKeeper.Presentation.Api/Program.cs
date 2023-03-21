using InfoKeeper.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvFiles(builder.Environment);

builder.Services
    .AddAllServices(builder.Configuration);

var app = builder.Build();

app.MapGraphQL();

app.Run();