using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookLibary.Api.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Yazar { get; set; }

        public int Durum { get; set; }


    }
}
