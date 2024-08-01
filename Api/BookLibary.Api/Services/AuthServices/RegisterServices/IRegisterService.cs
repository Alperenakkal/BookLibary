using BookLibary.Api.Dtos.UserDto;


namespace BookLibary.Api.Services.AuthServices.RegisterServices
{

    public interface IRegisterService
    {

        Task<string> Register(RegisterDto model);


    }
}
