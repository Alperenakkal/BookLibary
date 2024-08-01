using BookLibary.Api.Models.Request.UserRequest;
using BookLibary.Api.Models.Response.UserResponse;

namespace BookLibary.Api.Services.AuthServices.TokenServices
{
    public interface ITokenService
    {
       Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
        
    }
}
