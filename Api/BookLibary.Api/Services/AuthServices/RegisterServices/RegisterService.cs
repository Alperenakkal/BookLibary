using BookLibary.Api.Dtos.UserDto;
using BookLibary.Api.Models;
using BookLibary.Api.Repositories;
using System.Security.Cryptography;
using System.Text;


namespace BookLibary.Api.Services.AuthServices.RegisterServices
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository<User> _repository;
        private string hashedPassword;

        public RegisterService(IRegisterRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<string> Register(RegisterDto model)
        {
            var UserName = await _repository.GetByNameAsync(model.UserName);
            var Email =await _repository.GetByNameAsync(model.Email);

            SHA1 sha = new SHA1CryptoServiceProvider();

            if (UserName != null) 
            {
                return "Kullanılmış Kullanıcı Adı" ;
            }

            if (Email != null)
            {
                return "Kullanılmış Email";
            }

            if(model.Password.Trim() != model.PasswordRepeat.Trim())
            {
                return "Şifreler Uyuşmuyor";
            }

            hashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(model.Password)));

            var user = new User
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                Password = hashedPassword
            };

            await _repository.InsertOneAsync(user);
            return "x";
        }
    }
}
