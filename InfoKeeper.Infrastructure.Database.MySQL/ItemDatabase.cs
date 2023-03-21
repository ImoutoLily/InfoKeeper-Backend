using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;
using InfoKeeper.Infrastructure.Database.MySQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InfoKeeper.Infrastructure.Database.MySQL;

public class ItemDatabase : AbstractDatabase, IItemDatabase
{
    private readonly DbSet<Item> _items;

    public ItemDatabase(InfoKeeperContext context) : base(context)
    {
        _items = Context.Items;
    }

    public async Task<List<Item>> GetAsync()
    {
        return await _items.ToListAsync();
    }

    public async Task<Item?> GetAsync(string id)
    {
        return await _items.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Item> CreateAsync(Item item)
    {
        _items.Add(item);

        await Context.SaveChangesAsync();

        return item;
    }

    public async Task<Item?> UpdateAsync(Item item)
    {
        var storedItem = await _items.AsTracking()
            .SingleOrDefaultAsync(x => x.Id == item.Id);

        if (storedItem is null) return null;
        
        Context.Entry(storedItem).CurrentValues.SetValues(item);

        await Context.SaveChangesAsync();

        return storedItem;
    }

    public async Task<Item?> DeleteAsync(string id)
    {
        var item = await _items.SingleOrDefaultAsync(x => x.Id == id);

        if (item is null) return null;

        _items.Remove(item);

        await Context.SaveChangesAsync();

        return item;
    }

    public async Task<List<Item>> Search(string query)
    {
        return await _items.Where(x => x.MatchesQuery(query))
            .ToListAsync();
    }
}