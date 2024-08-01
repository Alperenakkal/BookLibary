using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookLibary.Api.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public object Id { get; set; }
        
        [BsonElement("BookName")]
        public string BookName { get; set; }

        public string Yazar { get; set; }

        public int Durum { get; set; }


    }
}
