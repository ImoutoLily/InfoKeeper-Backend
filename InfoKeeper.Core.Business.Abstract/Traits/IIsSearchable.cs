using InfoKeeper.Core.Business.Abstract.Models;

namespace InfoKeeper.Core.Business.Abstract.Traits;

public interface IIsSearchable<T>
{
    public Task<Result<List<T>>> Search(string query);
}