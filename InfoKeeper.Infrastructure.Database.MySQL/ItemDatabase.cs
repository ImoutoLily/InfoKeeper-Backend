using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;
using Microsoft.EntityFrameworkCore;

namespace InfoKeeper.Infrastructure.Database.MySQL;

public class ItemDatabase : AbstractDatabase, IItemDatabase
{
    public ItemDatabase(InfoKeeperContext context) : base(context)
    {
    }

    public async Task<List<Item>> GetAsync()
    {
        return await Context.Items
            .Include(x => x.Tags)
            .ToListAsync();
    }

    public async Task<Item?> GetAsync(int id)
    {
        return await Context.Items
            .Include(x => x.Tags)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Item> CreateAsync(Item item)
    {
        item.Tags = await LoadTags(item.Tags);
        
        Context.Items
            .Add(item);

        await Context.SaveChangesAsync();

        return item;
    }

    public async Task<Item?> UpdateAsync(Item item)
    {
        var storedItem = await Context.Items
            .AsTracking()
            .Include(x => x.Tags)   
            .SingleOrDefaultAsync(x => x.Id == item.Id);

        if (storedItem is null) return null;
        
        Context.Entry(storedItem)
            .CurrentValues
            .SetValues(item);

        storedItem.Tags = await LoadTags(item.Tags);

        await Context.SaveChangesAsync();

        return storedItem;
    }

    public async Task<Item?> DeleteAsync(int id)
    {
        var item = await Context.Items
            .Include(x => x.Tags)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (item is null) return null;

        Context.Items
            .Remove(item);

        await Context.SaveChangesAsync();

        return item;
    }

    public async Task<List<Item>> Search(string query)
    {
        return await Context.Items
            .Include(x => x.Tags)
            .Where(x => x.Title.Contains(query) || x.Content.Contains(query))
            .ToListAsync();
    }

    private async Task<List<Tag>> LoadTags(IList<Tag> tags)
    {
        return await Context.Tags
            .Where(x => tags.Select(y => y.Id).Contains(x.Id))
            .ToListAsync();
    }
}