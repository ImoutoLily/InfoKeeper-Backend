using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;
using Microsoft.EntityFrameworkCore;

namespace InfoKeeper.Infrastructure.Database.MySQL;

public class TagDatabase : AbstractDatabase, ITagDatabase
{
    public TagDatabase(InfoKeeperContext context) : base(context)
    {
    }

    public async Task<List<Tag>> GetAsync()
    {
        return await Context.Tags
            .Include(x => x.Items)
            .ToListAsync();
    }

    public async Task<Tag?> GetAsync(int id)
    {
        return await Context.Tags
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
        tag.Items = await LoadItems(tag.Items);
        
        Context.Tags
            .Add(tag);

        await Context.SaveChangesAsync();
        
        return tag;
    }

    public async Task<Tag?> UpdateAsync(Tag tag)
    {
        var storedTag = await Context.Tags
            .AsTracking()
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.Id == tag.Id);

        if (storedTag is null) return null;
        
        Context.Entry(storedTag)
            .CurrentValues
            .SetValues(tag);

        storedTag.Items = await LoadItems(tag.Items);

        await Context.SaveChangesAsync();

        return storedTag;
    }

    public async Task<Tag?> DeleteAsync(int id)
    {
        var tag = await Context.Tags
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (tag is null) return null;

        Context.Tags
            .Remove(tag);

        await Context.SaveChangesAsync();

        return tag;
    }
    
    private async Task<List<Item>> LoadItems(IList<Item> items)
    {
        return await Context.Items
            .Where(x => items.Select(y => y.Id).Contains(x.Id))
            .ToListAsync();
    }
}