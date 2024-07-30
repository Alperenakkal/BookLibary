using BookLibary.Api.Dtos;
using BookLibary.Api.Dtos.BookDto;
using BookLibary.Api.Dtos.UserDto;

namespace BookLibary.Api.Services.UserService
{
    public interface IUserServices
    {
        Task<LoginDto> LoginAsync(string name);
        Task<CreateUserDto> CreateUserAsync(CreateUserDto model);



    }
}
