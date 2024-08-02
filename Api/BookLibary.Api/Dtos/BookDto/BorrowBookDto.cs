using MongoDB.Bson;

namespace BookLibary.Api.Dtos.BookDto
{
    public class BorrowBookDto
    {
        public ObjectId Id { get; set; }


        public string? Name { get; set; }

        public string? Author { get; set; }

        public bool Available { get; set; }

        public DateTime BorrowDate {get; set;}

        public DateTime DueDate{get; set;}
    }
}
