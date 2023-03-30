using HotChocolate.Language;
using InfoKeeper.Core.Business.Abstract;
using InfoKeeper.Core.Models;
using InfoKeeper.Presentation.Api.GraphQL.Models;
using Mapster;

namespace InfoKeeper.Presentation.Api.GraphQL.Mutations;

[ExtendObjectType(OperationType.Mutation)]
public class TagMutation
{
    public async Task<Tag> CreateTagAsync([Service] ITagService service, TagRequest input)
    {
        var tag = input.Adapt<Tag>();
        
        var result = await service.CreateAsync(tag);

        return result.Value!;
    }

    public async Task<Tag?> UpdateTagAsync([Service] ITagService service, TagRequest input, int id)
    {
        var tag = input.Adapt<Tag>();

        tag.Id = id;
        
        var result = await service.UpdateAsync(tag);

        return result.Value!;
    }

    public async Task<Tag?> DeleteTagAsync([Service] ITagService service, int id)
    {
        var result = await service.DeleteAsync(id);

        return result.Value!;
    }
}