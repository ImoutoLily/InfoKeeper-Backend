using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.GraphQL.Queries;

[ExtendObjectType(OperationType.Query)]
public class TagQuery
{
    public async Task<List<Tag>> GetTagsAsync([Service] ITagService service)
        => await service.GetAsync();

    public async Task<Tag?> GetTagAsync([Service] ITagService service, int id)
        => await service.GetAsync(id);
}