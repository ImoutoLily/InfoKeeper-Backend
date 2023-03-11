using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InfoKeeper.Infrastructure.Database.MongoDB.Models;

public class DatabaseTag
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
}