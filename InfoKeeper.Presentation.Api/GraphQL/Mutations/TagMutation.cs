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
        
        return await service.CreateAsync(tag);
    }

    public async Task<Tag?> UpdateTagAsync([Service] ITagService service, TagRequest input, int id)
    {
        var tag = input.Adapt<Tag>();

        tag.Id = id;
        
        return await service.UpdateAsync(tag);
    }

    public async Task<Tag?> DeleteTagAsync([Service] ITagService service, int id)
        => await service.DeleteAsync(id);
}