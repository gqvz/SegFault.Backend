using MongoDB.Bson.Serialization.Attributes;

namespace SegFault.Backend.Database;

public record Review
{
    [BsonId]
    public required string Id { get; set; }
    
    [BsonElement]
    public required string Target { get; set; }
    
    [BsonElement]
    public required string ReviewerName { get; set; }
    
    [BsonElement]
    public required uint ReviewerId { get; set; }
    
    [BsonElement]
    public string? Text { get; set; }
    
    [BsonElement]
    public DateTime Timestamp { get; set; }
    
    [BsonElement]
    public Dictionary<string, int> CustomParameters { get; set; } = new();
}