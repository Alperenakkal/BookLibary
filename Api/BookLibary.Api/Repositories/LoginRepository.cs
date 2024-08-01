
using BookLibary.Api.Data.Context;
using BookLibary.Api.Models;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;

namespace BookLibary.Api.Repositories
{
    public class LoginRepository<T> : IRepository<T> where T : class
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<User> _model;

        public LoginRepository(MongoDbContext context)
        {
            _model = context.GetCollection<User>("Users");
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

            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
