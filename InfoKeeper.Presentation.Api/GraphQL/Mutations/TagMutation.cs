using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.GraphQL.Mutations;

[ExtendObjectType(Name = "Mutation")]
public class TagMutation
{
    public async Task<Tag> CreateTagAsync([Service] ITagService service, Tag tag)
        => await service.CreateAsync(tag);

    public async Task<Tag?> UpdateTagAsync([Service] ITagService service, string id, Tag tag)
        => await service.UpdateAsync(id, tag);

    public async Task<Tag?> DeleteItemAsync([Service] ITagService service, string id)
        => await service.DeleteAsync(id);
}