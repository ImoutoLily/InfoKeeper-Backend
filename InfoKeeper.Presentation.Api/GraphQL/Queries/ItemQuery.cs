using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.GraphQL.Queries;

[ExtendObjectType(OperationType.Query)]
public class ItemQuery
{
    public async Task<List<Item>> GetItemsAsync([Service] IItemService service)
    {
        var result = await service.GetAsync();

        return result.Value!;
    }

    public async Task<Item?> GetItemAsync([Service] IItemService service, int id)
    {
        var result = await service.GetAsync(id);

        return result.Value!;
    }

    public async Task<List<Item>> SearchItemsAsync([Service] IItemService service, string query)
    {
        var result = await service.Search(query);

        return result.Value!;
    }
}