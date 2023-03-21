using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.GraphQL.Mutations;

[ExtendObjectType(OperationType.Mutation)]
public class TagMutation
{
    public async Task<Tag> CreateTagAsync([Service] ITagService service, Tag tag)
        => await service.CreateAsync(tag);

    public async Task<Tag?> UpdateTagAsync([Service] ITagService service, Tag tag)
        => await service.UpdateAsync(tag);

    public async Task<Tag?> DeleteTagAsync([Service] ITagService service, int id)
        => await service.DeleteAsync(id);
}