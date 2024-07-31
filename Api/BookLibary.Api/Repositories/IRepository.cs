using BookLibary.Api.Dtos;
using BookLibary.Api.Models;

namespace BookLibary.Api.Repositories
{
    public interface IRepository<T> where T :  class 
    {
      

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task<T> GetByNameAsync (string name);

        





    }
}
