namespace InfoKeeper.Shared.Traits;

public interface IIsSearchable<T>
{
    public Task<List<T>> Search(string query);
}