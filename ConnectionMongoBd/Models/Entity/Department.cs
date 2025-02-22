using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Department
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } // ✅ Make it nullable to allow auto-generation

    public string Departments { get; set; } = string.Empty; // ✅ Prevent null issues
}
