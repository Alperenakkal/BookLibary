﻿
using BookLibary.Api.Dtos.UserDto;
using BookLibary.Api.Models;
using BookLibary.Api.Repositories;

namespace BookLibary.Api.Services.AuthServices.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository<User> _repository;

        public LoginService(IUserRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> GetByNameAsync(string name)
        {
          

            User user = await _repository.GetByNameAsync(name); 
            return user;
        }
    }
}