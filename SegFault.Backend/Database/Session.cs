using MongoDB.Bson.Serialization.Attributes;

namespace SegFault.Backend.Database;

public record Session
{
    [BsonId]
    public required uint EnrollmentNumber { get; set; }
    
    [BsonElement]
    public required string SessionToken { get; set; }
}