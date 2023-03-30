namespace InfoKeeper.Infrastructure.Database.Abstract.Traits;

public interface IIsSearchable<T>
{
    public Task<List<T>> Search(string query);
}