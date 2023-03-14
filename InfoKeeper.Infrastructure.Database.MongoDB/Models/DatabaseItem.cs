using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InfoKeeper.Infrastructure.Database.MongoDB.Models;

public class DatabaseItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreationDateTime { get; set; }

    public List<DatabaseTag> Tags { get; set; } = null!;
}