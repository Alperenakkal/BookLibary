
using BookLibary.Api.Data.Context;

namespace BookLibary.Api.Repositories
{
    public class UserRepository<T> : IRepository<T> where T : class
    {
        private readonly UserLibaryDbContext _context;

        public UserRepository(UserLibaryDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

      

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

         public async Task<T> GetByNameAsync(string name)
        {
            return await _context.Set<T>().FindAsync(name);
        }
    }
}
