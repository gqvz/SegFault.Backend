using MongoDB.Bson.Serialization.Attributes;

namespace SegFault.Backend.Database;

public record MenuItem
{
    
    [BsonElement]
    public required uint Price;

    [BsonElement]
    public required string Name;

    [BsonId]
    public required string Id;
}