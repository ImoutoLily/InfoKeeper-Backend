using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;
using InfoKeeper.Presentation.Api.GraphQL.Models;
using Mapster;

namespace InfoKeeper.Presentation.Api.GraphQL.Mutations;

[ExtendObjectType(OperationType.Mutation)]
public class ItemMutation
{
    public async Task<Item> CreateItemAsync([Service] IItemService service, ItemInput input)
    {
        var item = input.Adapt<Item>();
        
        var result = await service.CreateAsync(item);

        return result.Value!;
    }

    public async Task<Item?> UpdateItemAsync([Service] IItemService service, ItemInput input, int id)
    {
        var item = input.Adapt<Item>();
        
        item.Id = id;
        
        var result = await service.UpdateAsync(item);

        return result.Value!;
    }

    public async Task<Item?> DeleteItemAsync([Service] IItemService service, int id)
    {
        var result = await service.DeleteAsync(id);

        return result.Value!;
    }
}