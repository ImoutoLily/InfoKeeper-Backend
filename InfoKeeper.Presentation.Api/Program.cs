using System.Collections.Immutable;
using InfoKeeper.Core.Models;
using InfoKeeper.Presentation.Api.Extensions;
using InfoKeeper.Presentation.Api.GraphQL.Models;
using Mapster;

var builder = WebApplication.CreateBuilder(args);

TypeAdapterConfig<TagRequest, Tag>.NewConfig()
    .Map(dest => dest.Items, 
        src => (src.ItemIds ?? ImmutableList<int>.Empty).Select(x => new Item { Id = x }));

TypeAdapterConfig<ItemRequest, Item>.NewConfig()
    .Map(dest => dest.Tags, 
        src => (src.TagIds ?? ImmutableList<int>.Empty).Select(x => new Item { Id = x }));

builder.Configuration
    .AddEnvFiles(builder.Environment);

builder.Services
    .AddAllServices(builder.Configuration);

var app = builder.Build();

app.MapGraphQL();

app.Run();