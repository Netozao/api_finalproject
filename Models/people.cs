using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace peopleAPI.Models
{
    public class People
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DateofBirth { get; set; }
        public string Home { get; set; }
        public string Url { get; set; }
        public string FamilyGroup { get; set; }
    }
}