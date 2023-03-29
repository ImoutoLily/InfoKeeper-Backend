using InfoKeeper.Core.Models;
using InfoKeeper.Shared.Traits;

namespace InfoKeeper.Infrastructure.Database.Abstract;

public interface IItemDatabase : IHasCrudOperations<Item>, IIsSearchable<Item>
{
    
}