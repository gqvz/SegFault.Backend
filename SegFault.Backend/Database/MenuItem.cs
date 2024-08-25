using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SegFault.Backend.Database;

public record MenuItem
{
    [BsonId] [JsonProperty("id")] public required ObjectId Identity;

    [BsonElement("name")] [JsonProperty("name")]
    public required string Name;

    [BsonElement("type")] [JsonProperty("type")] public string Type;
    [BsonElement("serves")] [JsonProperty("serves")] public int Serves;
    [BsonElement("rating")] [JsonProperty("rating")] public double Rating;
    [BsonElement("imgURL")] [JsonProperty("imgURL")] public string ImageUrl;
    [BsonElement("canteen_id")] [JsonProperty("canteen_id")] public int CanteenId;
    [BsonElement("reviewIDs")] [JsonProperty("reviewIDs")] public List<int> ReviewIds;

    [BsonElement("price")] [JsonProperty("price")] public required int Price;

    [BsonElement("props")] public List<string> Props { get; set; } = [];

    public Dictionary<string, float> Ratings { get; set; } = new();
}