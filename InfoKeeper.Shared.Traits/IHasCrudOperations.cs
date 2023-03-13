namespace InfoKeeper.Shared.Traits;

public interface IHasCrudOperations<T>
{
    public Task<List<T>> GetAsync();
    public Task<T?> GetAsync(string id);
    public Task<T> CreateAsync(T t);
    public Task<T?> UpdateAsync(string id, T t);
    public Task<T?> DeleteAsync(string id);
}