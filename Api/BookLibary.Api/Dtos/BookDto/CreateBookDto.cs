using MongoDB.Bson;

namespace BookLibary.Api.Dtos.BookDto
{
    public class CreateBookDto
    {
        public ObjectId Id { get; set; }


        public string? Name { get; set; }

        public string? Author { get; set; }

        public bool Available { get; set; }
    }
}
