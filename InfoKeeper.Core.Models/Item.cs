namespace InfoKeeper.Core.Models;

public class Item
{
    public string? Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreationTimeStamp { get; set; }

    public IList<Tag> Tags { get; set; } = null!;
}