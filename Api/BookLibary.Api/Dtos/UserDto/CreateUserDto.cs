namespace BookLibary.Api.Dtos.UserDto
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        public required string  UserName { get; set; }

        public string? FullName { get; set; }
        public required string Password { get; set; }
        public string ?Email { get; set; }
    }
}
