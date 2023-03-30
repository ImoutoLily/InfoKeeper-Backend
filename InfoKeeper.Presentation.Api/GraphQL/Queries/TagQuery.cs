using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.GraphQL.Queries;

[ExtendObjectType(OperationType.Query)]
public class TagQuery
{
    public async Task<List<Tag>> GetTagsAsync([Service] ITagService service)
    {
        var result = await service.GetAsync();

        return result.Value!;
    }

    public async Task<Tag?> GetTagAsync([Service] ITagService service, int id)
    {
        var result = await service.GetAsync(id);

        return result.Value!;
    }
}