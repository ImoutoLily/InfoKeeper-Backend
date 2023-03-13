using InfoKeeper.Core.Business.Abstract;
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
    
    public async Task<List<Tag>> GetAsync()
    {
        return await _database.GetAsync();
    }

    public async Task<Tag?> GetAsync(string id)
    {
        return await _database.GetAsync(id);
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
        return await _database.CreateAsync(tag);
    }

    public async Task<Tag?> UpdateAsync(string id, Tag tag)
    {
        return await _database.UpdateAsync(id, tag);
    }

    public async Task<Tag?> DeleteAsync(string id)
    {
        return await _database.DeleteAsync(id);
    }
}