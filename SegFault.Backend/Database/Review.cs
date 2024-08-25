using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SegFault.Backend.Database;

public record Review
{
    [BsonId] [JsonProperty("id")] 
    public required ObjectId Identity { get; set; }
    
    [BsonElement("Target")]
    public required string Target { get; set; }
    
    [BsonElement("reviewerId")]
    public required uint ReviewerId { get; set; }
    
    [BsonElement]
    public string? Text { get; set; }
    
    [BsonElement("timestamp")]
    public long Timestamp { get; set; }
    
    [BsonElement]
    public Dictionary<string, int> CustomParameters { get; set; } = new();
}

public record ReviewReq
{
    public required string Target { get; set; }
    
    public required uint ReviewerId { get; set; }
    
    public string? Text { get; set; }
    
    public long Timestamp { get; set; }
    
    public Dictionary<string, int> CustomParameters { get; set; } = new();
}