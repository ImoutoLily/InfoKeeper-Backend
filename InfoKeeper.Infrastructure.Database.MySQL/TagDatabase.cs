using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;
using Microsoft.EntityFrameworkCore;

namespace InfoKeeper.Infrastructure.Database.MySQL;

public class TagDatabase : AbstractDatabase, ITagDatabase
{
    private readonly DbSet<Tag> _tags;

    public TagDatabase(InfoKeeperContext context) : base(context)
    {
        _tags = context.Tags;
    }

    public async Task<List<Tag>> GetAsync()
    {
        return await _tags.ToListAsync();
    }

    public async Task<Tag?> GetAsync(int id)
    {
        return await _tags.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
        _tags.Add(tag);

        await Context.SaveChangesAsync();
        
        return tag;
    }

    public async Task<Tag?> UpdateAsync(Tag tag)
    {
        var storedTag = await _tags.AsTracking()
            .SingleOrDefaultAsync(x => x.Id == tag.Id);

        if (storedTag is null) return null;
        
        Context.Entry(storedTag).CurrentValues.SetValues(tag);

        await Context.SaveChangesAsync();

        return storedTag;
    }

    public async Task<Tag?> DeleteAsync(int id)
    {
        var tag = await _tags.SingleOrDefaultAsync(x => x.Id == id);

        if (tag is null) return null;

        _tags.Remove(tag);

        await Context.SaveChangesAsync();

        return tag;
    }
}