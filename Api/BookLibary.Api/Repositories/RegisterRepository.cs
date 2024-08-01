using BookLibary.Api.Data.Context;
using BookLibary.Api.Models;
using MongoDB.Driver;
using SharpCompress.Common;

namespace BookLibary.Api.Repositories
{
    public class RegisterRepository : IRegisterRepository<User>
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<User> _model;

        public RegisterRepository(MongoDbContext context)
        {
            _context = context;
            _model = context.GetCollection<User>("Users");
        }
        public async Task<User> GetByNameAsync(string name)
        {
            var filter = Builders<User>.Filter.Eq(x => x.UserName, name);
            return await _model.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Email, email);
            return await _model.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<User> InsertOneAsync(User user)
        {
            await _model.InsertOneAsync(user);
            return user;
        }
    }
}