using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Business.Abstract.Models;
using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;

namespace InfoKeeper.Core.Business;

public class TagService : ITagService
{
    private readonly ITagDatabase _database;

    public TagService(ITagDatabase database)
    {
        _database = database;
    }
    
    public async Task<Result<List<Tag>>> GetAsync()
    {
        var tags = await _database.GetAsync();
        
        return Result.Ok(tags);
    }

    public async Task<Result<Tag?>> GetAsync(int id)
    {
        var tag = await _database.GetAsync(id);

        return Result.Ok(tag);
    }

    public async Task<Result<Tag>> CreateAsync(Tag tag)
    {
        var storedTag = await _database.CreateAsync(tag);

        return Result.Ok(storedTag);
    }

    public async Task<Result<Tag?>> UpdateAsync(Tag tag)
    {
        var storedTag = await _database.UpdateAsync(tag);

        return Result.Ok(storedTag);
    }

    public async Task<Result<Tag?>> DeleteAsync(int id)
    {
        var tag = await _database.DeleteAsync(id);

        return Result.Ok(tag);
    }
}