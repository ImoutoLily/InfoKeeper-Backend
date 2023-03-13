using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;

namespace InfoKeeper.Core.Business;

public class ItemService : IItemService
{
    private readonly IItemDatabase _database;

    public ItemService(IItemDatabase database)
    {
        _database = database;
    }

    public async Task<List<Item>> GetAsync()
    {
        return await _database.GetAsync();
    }

    public async Task<Item?> GetAsync(string id)
    {
        return await _database.GetAsync(id);
    }

    public async Task<Item> CreateAsync(Item item)
    {
        return await _database.CreateAsync(item);
    }

    public async Task<Item?> UpdateAsync(string id, Item item)
    {
        return await _database.UpdateAsync(id, item);
    }

    public async Task<Item?> DeleteAsync(string id)
    {
        return await _database.DeleteAsync(id);
    }

    public async Task<List<Item>> Search(string query)
    {
        return await _database.Search(query);
    }
}