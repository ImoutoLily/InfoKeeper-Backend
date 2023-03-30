using FluentValidation;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Business.Abstract.Models;
using InfoKeeper.Core.Models;
using InfoKeeper.Infrastructure.Database.Abstract;

namespace InfoKeeper.Core.Business;

public class ItemService : IItemService
{
    private readonly IItemDatabase _database;
    private readonly IValidator<Item> _validator;

    public ItemService(IItemDatabase database, IValidator<Item> validator)
    {
        _database = database;
        _validator = validator;
    }

    public async Task<Result<List<Item>>> GetAsync()
    {
        var items = await _database.GetAsync();

        return Result.Ok(items);
    }

    public async Task<Result<Item?>> GetAsync(int id)
    {
        var item = await _database.GetAsync(id);

        return Result.Ok(item);
    }

    public async Task<Result<Item>> CreateAsync(Item item)
    {
        var storedItem = await _database.CreateAsync(item);

        return Result.Ok(storedItem);
    }

    public async Task<Result<Item?>> UpdateAsync(Item item)
    {
        var storedItem = await _database.UpdateAsync(item);
        
        return Result.Ok(storedItem);
    }

    public async Task<Result<Item?>> DeleteAsync(int id)
    {
        var item = await _database.DeleteAsync(id);
        
        return Result.Ok(item);
    }

    public async Task<Result<List<Item>>> Search(string query)
    {
        var items = await _database.Search(query);
        
        return Result.Ok(items);
    }
}