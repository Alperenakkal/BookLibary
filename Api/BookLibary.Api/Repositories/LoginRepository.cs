
using BookLibary.Api.Data.Context;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;

namespace BookLibary.Api.Repositories
{
    public class LoginRepository<T> : IRepository<T> where T : class
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<T> _collection;

        public LoginRepository(MongoDbContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByNameAsync(string name)
        {
            var filter = Builders<T>.Filter.Eq("UserName", name);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
