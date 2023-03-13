using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.GraphQL.Mutations;

[ExtendObjectType(Name = "Mutation")]
public class ItemMutation
{
    public async Task<Item> CreateItemAsync([Service] IItemService service, Item item) 
        => await service.CreateAsync(item);

    public async Task<Item?> UpdateItemAsync([Service] IItemService service, string id, Item item)
        => await service.UpdateAsync(id, item);

    public async Task<Item?> DeleteItemAsync([Service] IItemService service, string id)
        => await service.DeleteAsync(id);
}