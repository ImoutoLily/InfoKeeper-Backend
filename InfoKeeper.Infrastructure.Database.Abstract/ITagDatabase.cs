using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract.Traits;

namespace InfoKeeper.Infrastructure.Database.Abstract;

public interface ITagDatabase : IHasCrudOperations<Tag>
{
    
}