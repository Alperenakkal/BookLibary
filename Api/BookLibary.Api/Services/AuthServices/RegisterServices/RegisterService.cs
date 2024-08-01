using BookLibary.Api.Dtos.UserDto;
using BookLibary.Api.Models;
using BookLibary.Api.Repositories;

namespace BookLibary.Api.Services.AuthServices.RegisterServices
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository<User> _repository;

        public RegisterService(IRegisterRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<string> Register(RegisterDto model)
        {
            var UserName = await _repository.GetByNameAsync(model.UserName);
            var Email =await _repository.GetByNameAsync(model.Email);

            if (UserName != null) {
                return "Kullanılmış Kullanıcı Adı" ;
            }
            if (Email != null)
            {
                return "Kullanılmış Email";
            }


            var user = new User
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password
            };

            await _repository.InsertOneAsync(user);
            return "x";
        }
    }
}
