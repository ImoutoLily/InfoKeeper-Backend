using InfoKeeper.Configuration.Settings;
using InfoKeeper.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var databaseSettings = new InfoKeeperDatabaseSettings();
builder.Configuration.Bind("InfoKeeperDatabaseSettings", databaseSettings);

builder.Services.AddAllServices(databaseSettings);

var app = builder.Build();

app.MapGraphQL();

app.Run();