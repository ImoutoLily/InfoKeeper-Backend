using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;
using InfoKeeper.Presentation.Api.GraphQL.Models;
using Mapster;

namespace InfoKeeper.Presentation.Api.GraphQL.Mutations;

[ExtendObjectType(OperationType.Mutation)]
public class ItemMutation
{
    public async Task<Item> CreateItemAsync([Service] IItemService service, ItemRequest input)
    {
        var item = input.Adapt<Item>();
        
        return await service.CreateAsync(item);
    }

    public async Task<Item?> UpdateItemAsync([Service] IItemService service, ItemRequest input, int id)
    {
        var item = input.Adapt<Item>();
        
        item.Id = id;
        
        return await service.UpdateAsync(item);
    }

    public async Task<Item?> DeleteItemAsync([Service] IItemService service, int id)
        => await service.DeleteAsync(id);
}