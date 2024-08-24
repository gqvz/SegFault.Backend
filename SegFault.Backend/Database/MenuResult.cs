using MongoDB.Bson.Serialization.Attributes;

namespace SegFault.Backend.Database;

public record MenuResult
{
    [BsonId]
    public required string Bhawan;
    
    [BsonElement]
    public List<MenuItem> Day = new List<MenuItem>();
    
    [BsonElement]
    public List<MenuItem> Night = new List<MenuItem>();
}