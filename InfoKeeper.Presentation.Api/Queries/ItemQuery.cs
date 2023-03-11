using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.Queries;

public class ItemQuery
{
    public Item GetItem() => new Item
    {
        Id = "1234",
        Title = "Sample item",
        Content = "The content of the item",
        CreationTimeStamp = DateTime.Now,
        Tags = new List<Tag>
        {
            new Tag { Id = "1000", Name = "Link", Color = "#111111" },
            new Tag { Id = "1001", Name = "Important", Color = "#992222" }
        }
    };
}