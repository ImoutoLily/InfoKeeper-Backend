namespace InfoKeeper.Infrastructure.Database.MySQL;

public abstract class AbstractDatabase
{
    protected readonly InfoKeeperContext Context;

    protected AbstractDatabase(InfoKeeperContext context)
    {
        Context = context;
    }
}