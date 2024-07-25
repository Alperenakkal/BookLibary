namespace BookLibary.Web.Dtos
{
    public class CreateBookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Yazar { get; set; }
        public int Durum { get; set; }
    }
}
