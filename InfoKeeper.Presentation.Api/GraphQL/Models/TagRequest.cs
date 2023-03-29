namespace InfoKeeper.Presentation.Api.GraphQL.Models;

public class TagRequest
{
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;

    public IList<int>? ItemIds { get; set; }
}