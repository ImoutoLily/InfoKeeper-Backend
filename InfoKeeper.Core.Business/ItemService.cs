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

    public async Task<Item?> GetAsync(int id)
    {
        return await _database.GetAsync(id);
    }

    public async Task<Item> CreateAsync(Item item)
    {
        return await _database.CreateAsync(item);
    }

    public async Task<Item?> UpdateAsync(Item item)
    {
        return await _database.UpdateAsync(item);
    }

    public async Task<Item?> DeleteAsync(int id)
    {
        return await _database.DeleteAsync(id);
    }

    public async Task<List<Item>> Search(string query)
    {
        return await _database.Search(query);
    }
}