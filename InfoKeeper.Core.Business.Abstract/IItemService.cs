using InfoKeeper.Core.Models;
using InfoKeeper.Shared.Traits;

namespace InfoKeeper.Core.Business.Abstract;

public interface IItemService : IHasCrudOperations<Item>, IIsSearchable<Item>
{
    
}