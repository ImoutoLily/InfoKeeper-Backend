using InfoKeeper.Configuration.Settings;
using InfoKeeper.Core.Business;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Infrastructure.Database.Abstract;
using InfoKeeper.Infrastructure.Database.MongoDB;
using InfoKeeper.Presentation.Api.GraphQL.Mutations;
using InfoKeeper.Presentation.Api.GraphQL.Queries;

namespace InfoKeeper.Presentation.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services, 
        InfoKeeperDatabaseSettings databaseSettings)
    {
        services
            .AddConfiguration(databaseSettings)
            .AddDatabase()
            .AddBusinessLogic()
            .AddGraphQl();

        return services;
    }

    private static IServiceCollection AddConfiguration(this IServiceCollection services, 
        InfoKeeperDatabaseSettings databaseSettings)
    {
        return services.AddSingleton(databaseSettings);
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        return services.AddTransient<ITagDatabase, TagDatabase>()
            .AddTransient<IItemDatabase, ItemDatabase>();
    }

    private static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        return services.AddTransient<ITagService, TagService>()
            .AddTransient<IItemService, ItemService>();
    }

    private static void AddGraphQl(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType()
            .AddTypeExtension<TagQuery>()
            .AddTypeExtension<ItemQuery>()
            .AddMutationType()
            .AddTypeExtension<TagMutation>()
            .AddTypeExtension<ItemMutation>();
    }
}