using InfoKeeper.Core.Business.Abstract.Models;

namespace InfoKeeper.Core.Business.Abstract.Traits;

public interface ISearchable<T>
{
    public Task<Result<List<T>>> Search(string query);
}