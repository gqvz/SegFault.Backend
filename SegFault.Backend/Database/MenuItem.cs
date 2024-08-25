using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SegFault.Backend.Database;

public record MenuItem
{
    [BsonId]
    [JsonProperty("id")]
    public required string Id;
    
    [BsonElement]
    [JsonProperty("name")]
    public required string Name;
    
    [BsonElement]
    [JsonProperty("price")]
    public required uint Price;

    [BsonElement]
    public List<string> AllowedParameters { get; set; } = [];
    
    [BsonElement]
    public Dictionary<string, float> Ratings { get; set; } = new();
}