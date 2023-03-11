using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;
using InfoKeeper.Infrastructure.Database.MongoDB.Models;
using Mapster;
using MongoDB.Driver;

namespace InfoKeeper.Infrastructure.Database.MongoDB;

public class ItemDatabase : IItemDatabase
{
    private readonly IMongoCollection<DatabaseItem> _itemCollection;

    public ItemDatabase()
    {
        _itemCollection = null!;
    }

    public async Task<List<Item>> GetAsync()
    {
        var items = await _itemCollection.Find(_ => true)
            .ToListAsync();

        return items.Adapt<List<Item>>();
    }

    public async Task<Item?> GetAsync(string id)
    {
        var item = await _itemCollection.Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        return item?.Adapt<Item>();
    }

    public async Task<Item> CreateAsync(Item item)
    {
        await _itemCollection.InsertOneAsync(item.Adapt<DatabaseItem>());

        var savedItem = await _itemCollection.Find(x => x.Id == item.Id)
            .FirstOrDefaultAsync();

        return savedItem.Adapt<Item>();
    }

    public async Task<Item?> UpdateAsync(string id, Item item)
    {
        await _itemCollection.ReplaceOneAsync(x => x.Id == id, item.Adapt<DatabaseItem>());

        var savedItem = await _itemCollection.Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        return savedItem?.Adapt<Item>();
    }

    public async Task<Item?> DeleteAsync(string id)
    {
        var item = await _itemCollection.Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (item is null) return null;

        await _itemCollection.DeleteOneAsync(x => x.Id == id);

        return item.Adapt<Item>();
    }

    public async Task<List<Item>> Search(string query)
    {
        var items = await _itemCollection.Find(x => CheckIfItemMatchesQuery(x, query))
            .ToListAsync();

        return items.Adapt<List<Item>>();
    }

    private static bool CheckIfItemMatchesQuery(DatabaseItem item, string query)
    {
        var lowerQuery = query.ToLower();

        return item.Title.ToLower().Contains(lowerQuery) || item.Content.ToLower().Contains(lowerQuery);
    }
}