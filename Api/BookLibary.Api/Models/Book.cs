using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookLibary.Api.Models
{
    public class Book:IBook
    {
        [BsonId]

        public ObjectId Id { get; set; }
        
        [BsonElement("BookName")]
        public string? BookName { get; set; }

        public string? Publisher {get; set;}

        public string? Author { get; set; }

        public int Available { get; set; }


    }
}
