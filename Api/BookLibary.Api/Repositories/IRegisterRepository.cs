using BookLibary.Api.Models;

namespace BookLibary.Api.Repositories
{
    public interface IRegisterRepository<T> where T : class
    {

        Task<T> GetByNameAsync(string name);
        Task<T> GetByEmailAsync(string name);
        Task<T> InsertOneAsync(User user);


    }
}
