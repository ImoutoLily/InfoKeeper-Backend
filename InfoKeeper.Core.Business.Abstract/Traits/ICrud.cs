using InfoKeeper.Core.Business.Abstract.Models;

namespace InfoKeeper.Core.Business.Abstract.Traits;

public interface ICrud<T>
{
    public Task<Result<List<T>>> GetAsync();
    public Task<Result<T?>> GetAsync(int id);
    public Task<Result<T>> CreateAsync(T t);
    public Task<Result<T?>> UpdateAsync(T t);
    public Task<Result<T?>> DeleteAsync(int id);
}