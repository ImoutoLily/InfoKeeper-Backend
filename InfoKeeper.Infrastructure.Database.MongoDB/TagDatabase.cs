using InfoKeeper.Infrastructure.Database.Abstract;
using InfoKeeper.Infrastructure.Database.MongoDB.Models;
using Mapster;
using MongoDB.Driver;
using Tag = InfoKeeper.Core.Models.Tag;

namespace InfoKeeper.Infrastructure.Database.MongoDB;

public class TagDatabase : ITagDatabase
{
    private readonly IMongoCollection<DatabaseTag> _tagCollection;

    public TagDatabase()
    {
        _tagCollection = null!;
    }

    public async Task<List<Tag>> GetAsync()
    {
        var tags = await _tagCollection.Find(_ => true)
            .ToListAsync();

        return tags.Adapt<List<Tag>>();
    }

    public async Task<Tag?> GetAsync(string id)
    {
        var tag = await _tagCollection.Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        return tag?.Adapt<Tag>();
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
        await _tagCollection.InsertOneAsync(tag.Adapt<DatabaseTag>());

        var savedTag = await _tagCollection.Find(x => x.Id == tag.Id)
            .FirstOrDefaultAsync();

        return savedTag.Adapt<Tag>();
    }

    public async Task<Tag?> UpdateAsync(string id, Tag tag)
    {
        await _tagCollection.ReplaceOneAsync(x => x.Id == id, tag.Adapt<DatabaseTag>());
        
        var savedTag = await _tagCollection.Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        return savedTag?.Adapt<Tag>(); // TODO: check if this functions correctly  
    }

    public async Task<Tag?> DeleteAsync(string id)
    {
        var tag = await _tagCollection.Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (tag is null) return null;

        await _tagCollection.DeleteOneAsync(x => x.Id == id);

        return tag.Adapt<Tag>();
    }
}