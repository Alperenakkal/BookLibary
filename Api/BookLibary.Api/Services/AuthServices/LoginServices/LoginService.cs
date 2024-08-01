
using BookLibary.Api.Dtos.UserDto;
using BookLibary.Api.Models;
using BookLibary.Api.Models.Request.UserRequest;
using BookLibary.Api.Models.Response.UserResponse;
using BookLibary.Api.Repositories;
using BookLibary.Api.Services.AuthServices.TokenServices;
using System.Security.Cryptography;
using System.Text;

namespace BookLibary.Api.Services.AuthServices.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository<User> _repository;
<<<<<<< HEAD
        readonly ITokenService _tokenService;
        private string hashPassword;

=======
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _contextAccessor;
>>>>>>> 61acbc38aad5510d37032c40c5cea039d871b980


        public LoginService(IUserRepository<User> repository, ITokenService tokenService, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _tokenService = tokenService;
            _contextAccessor = contextAccessor;
        }

        public async Task<User> GetByNameAsync(string name)
        {
          

            User user = await _repository.GetByNameAsync(name); 
            return user;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            SHA1 sha = new SHA1CryptoServiceProvider();

            User user = await _repository.GetByNameAsync(request.Username);

            if (string.IsNullOrEmpty(request.Username) && string.IsNullOrEmpty(request.Password))
            {
                throw new NullReferenceException(nameof(request));
            }
            hashPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(request.Password)));
            if (request.Username == user.UserName && hashPassword == user.Password)
            {
                
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = request.Username });
                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = generatedTokenInformation.TokenExpireDate
                };
                _contextAccessor.HttpContext.Response.Cookies.Append("AuthToken", generatedTokenInformation.Token, cookieOptions);


            }
            return response;
        }
    }
}
