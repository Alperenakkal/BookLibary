using BookLibary.Api.Models;

namespace BookLibary.Api.Services.AuthServices.LoginServices
{
    public interface ILoginService
    {
        Task<User> GetByNameAsync(string name);
    }
}
