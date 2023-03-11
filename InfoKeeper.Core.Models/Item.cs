namespace InfoKeeper.Core.Models;

public class Item
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreationTimeStamp { get; set; }

    public List<Tag> Tags { get; set; } = null!;
}