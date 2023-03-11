using InfoKeeper.Core.Models;

namespace InfoKeeper.Presentation.Api.Queries;

public class ItemQuery
{
    public Item GetItem() => new Item { Text = "Sample item" };
}