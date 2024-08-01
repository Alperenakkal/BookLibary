using MongoDB.Bson;

namespace BookLibary.Api.Dtos.UserDto
{
    public class RegisterDto
    {
        public ObjectId Id { get; set; }
        public required string  UserName { get; set; }

        public string? FullName { get; set; }
        public required string Password { get; set; }
        public required string PasswordRepeat { get; set; }
        public string ?Email { get; set; }
    }
}
