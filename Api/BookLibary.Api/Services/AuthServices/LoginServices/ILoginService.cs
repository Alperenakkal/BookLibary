using BookLibary.Api.Models;
using BookLibary.Api.Models.Request.UserRequest;
using BookLibary.Api.Models.Response.UserResponse;

namespace BookLibary.Api.Services.AuthServices.LoginServices
{
    public interface ILoginService
    {
        Task<User> GetByNameAsync(string name);
        Task<LoginResponse> LoginUserAsync(LoginRequest request);
        Task LogoutUserAsync();

    }
}
