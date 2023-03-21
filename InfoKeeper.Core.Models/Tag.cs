namespace InfoKeeper.Core.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;

    public IList<Item> Items { get; set; } = null!;
}