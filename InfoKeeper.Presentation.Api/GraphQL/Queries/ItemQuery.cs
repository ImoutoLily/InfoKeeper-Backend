using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.GraphQL.Queries;

[ExtendObjectType(OperationType.Query)]
public class ItemQuery
{
    public async Task<List<Item>> GetItemsAsync([Service] IItemService service) 
        => await service.GetAsync();

    public async Task<Item?> GetItemAsync([Service] IItemService service, int id) 
        => await service.GetAsync(id);
    
    public async Task<List<Item>> SearchItemsAsync([Service] IItemService service, string query)
        => await service.Search(query);
}