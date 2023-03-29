using InfoKeeper.Core.Models;
using InfoKeeper.Shared.Traits;

namespace InfoKeeper.Infrastructure.Database.Abstract;

public interface ITagDatabase : IHasCrudOperations<Tag>
{
    
}