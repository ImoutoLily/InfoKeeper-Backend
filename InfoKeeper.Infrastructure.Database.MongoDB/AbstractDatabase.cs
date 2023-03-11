using InfoKeeper.Configuration.Settings;
using MongoDB.Driver;

namespace InfoKeeper.Infrastructure.Database.MongoDB;

public abstract class AbstractDatabase
{
    protected readonly IMongoDatabase Database;

    private protected AbstractDatabase(InfoKeeperDatabaseSettings settings)
    {
        var mongoClient = new MongoClient(settings.MongoUrl);

        Database = mongoClient.GetDatabase(settings.DatabaseName);
    }
}