namespace InfoKeeper.Configuration.Settings;

public class InfoKeeperDatabaseSettings
{
    public string MongoUrl { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string TagCollectionName { get; set; } = null!;
    public string ItemCollectionName { get; set; } = null!;
}