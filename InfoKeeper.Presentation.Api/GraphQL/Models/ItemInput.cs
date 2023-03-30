namespace InfoKeeper.Presentation.Api.GraphQL.Models;

public class ItemInput
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    
    public IList<int>? TagIds { get; set; }
}