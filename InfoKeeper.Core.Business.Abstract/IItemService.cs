using InfoKeeper.Core.Business.Abstract.Traits;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Core.Business.Abstract;

public interface IItemService : IHasCrudOperations<Item>, IIsSearchable<Item>
{
    
}