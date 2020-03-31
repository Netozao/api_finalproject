using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace photosAPI.Models
{
    public class photos
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Where { get; set; }
        public string url { get; set; }
    }
}