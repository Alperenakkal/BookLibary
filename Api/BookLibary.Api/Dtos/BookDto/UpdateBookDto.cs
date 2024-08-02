using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookLibary.Api.Dtos.BookDto
{
    public class UpdateBookDto
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("BookName")]

        public string? BookName { get; set; }

        public string? Author { get; set; }

        public bool Available { get; set; }
    }
}
