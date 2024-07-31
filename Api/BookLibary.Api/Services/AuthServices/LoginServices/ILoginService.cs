namespace BookLibary.Api.Services.AuthServices.LoginServices
{
    public interface ILoginService
    {
        Task<string> GetByNameAsync(string name);
    }
}
