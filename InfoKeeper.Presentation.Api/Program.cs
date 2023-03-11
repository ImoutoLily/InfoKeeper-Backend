using InfoKeeper.Presentation.Api.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<ItemQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();