using InfoKeeper.Configuration.Settings;
using InfoKeeper.Core.Business;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Infrastructure.Database.Abstract;
using InfoKeeper.Infrastructure.Database.MongoDB;
using InfoKeeper.Presentation.Api.Mutations;
using InfoKeeper.Presentation.Api.Queries;

var builder = WebApplication.CreateBuilder(args);

var databaseSettings = new InfoKeeperDatabaseSettings();
builder.Configuration.Bind("InfoKeeperDatabaseSettings", databaseSettings);
builder.Services.AddSingleton(databaseSettings);

builder.Services.AddTransient<ITagDatabase, TagDatabase>();
builder.Services.AddTransient<IItemDatabase, ItemDatabase>();

builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<IItemService, ItemService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(x => x.Name("Query"))
    .AddTypeExtension<TagQuery>()
    .AddTypeExtension<ItemQuery>()
    .AddMutationType(x => x.Name("Mutation"))
    .AddTypeExtension<TagMutation>()
    .AddTypeExtension<ItemMutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();