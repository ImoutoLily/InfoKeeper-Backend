namespace InfoKeeper.Infrastructure.Database.Abstract.Traits;

public interface ISearchable<T>
{
    public Task<List<T>> Search(string query);
}