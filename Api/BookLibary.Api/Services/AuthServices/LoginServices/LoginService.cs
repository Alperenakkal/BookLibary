
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
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Geçersiz kullanıcı adı.";
            }

            var user = await _repository.GetByNameAsync(name);

            if (user == null)
            {
                return "Böyle bir kullanıcı bulunamadı.";
            }

            var userName = user.UserName;

            if (userName == null)
            {
                return "Kullanıcı adı bilgisi bulunamadı.";
            }

            return userName;
        }
    }
}
