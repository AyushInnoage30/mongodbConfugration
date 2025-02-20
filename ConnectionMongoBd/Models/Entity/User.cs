using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ConnectionMongoBd.Models.Entity
{
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

    }
}
