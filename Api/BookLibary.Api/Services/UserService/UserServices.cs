using Azure.Identity;
using BookLibary.Api.Dtos;
using BookLibary.Api.Dtos.UserDto;
using BookLibary.Api.Models;
using BookLibary.Api.Repositories;


namespace BookLibary.Api.Services.UserService
{
    public class UserServices : IUserServices

    {
        private readonly IRepository<User> _repository;
        public UserServices(IRepository<User> repository) => _repository = repository; 
      

        public async Task<CreateUserDto> CreateUserAsync(CreateUserDto model)
        {
            var user = new User
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Password = model.Password,
                Email = model.Email,
            };
        
            await _repository.CreateAsync(user);
            var username = user.UserName;
            var password = user.Password;
            var email = user.Email;
            var fullName = user.FullName;

            var userDto = new CreateUserDto
            {
                UserName = username,
                Password = password,
                Email = email,
                FullName = fullName
            };


            return userDto;
          
        }

        public Task<LoginDto> LoginAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
