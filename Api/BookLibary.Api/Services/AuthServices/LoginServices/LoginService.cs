
using BookLibary.Api.Models;
using BookLibary.Api.Repositories;

namespace BookLibary.Api.Services.AuthServices.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<User> _repository;

        public LoginService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<string> GetByNameAsync(string name)
        {
            var user = await _repository.GetByNameAsync(name);
            string userName = user.UserName;
            if (userName == null) { return "Böyle bir kullanici bulunamadi"; }
            return userName;
            
        }
    }
}
