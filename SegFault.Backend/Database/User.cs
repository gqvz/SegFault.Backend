using MongoDB.Bson.Serialization.Attributes;

namespace SegFault.Backend.Database;

public record User
{
    [BsonId]
    public required uint EnrollmentNumber { get; set; }
    
    [BsonElement("password_hash")]
    public required string PasswordHash { get; set; }
    
    [BsonElement("name")]
    public required string Name { get; set; }
}