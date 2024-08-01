using BookLibary.Api.Data.Context;
using BookLibary.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookLibary.Api.Repositories
{
    public class LoginRepository : IRepository<User>
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<User> _model;

        public LoginRepository(MongoDbContext context)
        {
            _context = context;
            _model = context.GetCollection<User>("Users");
        }

        public Task CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public GetOneResult<User> DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<GetOneResult<User>> DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public GetOneResult<User> DeleteOne(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<GetOneResult<User>> DeleteOneAsync(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public GetManyResult<User> FilterBy(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<GetManyResult<User>> FilterByAsync(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public GetManyResult<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public GetOneResult<User> GetById(string id, string type = "object")
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetOneResult<User>> GetByIdAsync(string id, string type = "object")
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByNameAsync(string name)
        {
            var filter = Builders<User>.Filter.Eq(x => x.UserName, name);
            return await _model.Find(filter).FirstOrDefaultAsync();
        }

        public GetManyResult<User> InsertMany(ICollection<User> entities)
        {
            throw new NotImplementedException();
        }

        public Task<GetManyResult<User>> InsertManyAsync(ICollection<User> entities)
        {
            throw new NotImplementedException();
        }

        public GetOneResult<User> InsertOne(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<GetOneResult<User>> InsertOneAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public GetOneResult<User> ReplaceOne(User entity, string id, string type = "object")
        {
            throw new NotImplementedException();
        }

        public Task<GetOneResult<User>> ReplaceOneAsync(User entity, string id, string type = "object")
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<GetManyResult<User>> IRepository<User>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
