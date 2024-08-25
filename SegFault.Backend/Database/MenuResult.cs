using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SegFault.Backend.Database;

public record MenuResult
{
    [BsonId]
    [JsonProperty("bhawan")]
    public required string Bhawan;
    
    [BsonElement]
    [JsonProperty("day")]
    public List<string> Day = [];
    
    [BsonElement]
    [JsonProperty("night")]
    public List<string> Night = [];
}