using BookLibary.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookLibary.Api.Data.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    }
}
