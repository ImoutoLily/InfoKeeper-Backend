using FluentValidation;
using InfoKeeper.Core.Business;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Business.Validators;
using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;
using InfoKeeper.Infrastructure.Database.MySQL;
using InfoKeeper.Presentation.Api.GraphQL.Mutations;
using InfoKeeper.Presentation.Api.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;

namespace InfoKeeper.Presentation.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddContext(configuration)
            .AddDatabase()
            .AddValidators()
            .AddBusinessLogic()
            .AddGraphQl();

        return services;
    }

    private static IServiceCollection AddContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration["INFO_KEEPER_CONNECTION_STRING"];
        var version = configuration["INFO_KEEPER_VERSION"];

        if (connectionString is null || version is null) 
            throw new NullReferenceException("Not all required environment variables are set.");
        
        return services.AddDbContext<InfoKeeperContext>(x =>
        {
            x.UseMySql(connectionString, new MySqlServerVersion(new Version(version)));
            x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        return services.AddTransient<ITagDatabase, TagDatabase>()
            .AddTransient<IItemDatabase, ItemDatabase>();
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services.AddTransient<IValidator<Tag>, TagValidator>()
            .AddTransient<IValidator<Item>, ItemValidator>();
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