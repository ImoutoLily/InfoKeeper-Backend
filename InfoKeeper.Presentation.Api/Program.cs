using InfoKeeper.Configuration.Settings;
using InfoKeeper.Presentation.Api.Queries;

var builder = WebApplication.CreateBuilder(args);

var databaseSettings = new InfoKeeperDatabaseSettings();
builder.Configuration.Bind("InfoKeeperDatabaseSettings", databaseSettings);
builder.Services.AddSingleton(databaseSettings);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<ItemQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();