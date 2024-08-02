using System.Collections;
using BookLibary.Api.Data.Context;
using BookLibary.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;


namespace BookLibary.Api.Repositories
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly IMongoCollection<Book> _collection;
        private readonly MongoDbContext _context;
        
        private readonly IMongoCollection<Book> _model;
        private Web.Models.Book book;

        public BookRepository(MongoDbContext context,IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);
            
            _context = context;
            _model = context.GetCollection<Book>("Books");
            _collection = database.GetCollection<Book>(typeof(Book).Name);
           
        }
        public async Task<Book> GetByNameAsync(string name)
        {
            var filter = Builders<Book>.Filter.Eq(x => x.BookName, name);
            return await _model.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<Book> InsertOneAsync(Book book)
        {
            await _model.InsertOneAsync(book);
            return book;
        }
        public async Task<GetManyResult<Book>> GetAllAsync()
        {
            var result = new GetManyResult<Book>();
            try
            {
                var data = await _collection.AsQueryable().ToListAsync();
                result.Result = data;
            }
            catch (Exception ex)
            {
                result.Message = $"AsQueryable {ex.Message}";
                result.Success = false;
            }
            return result;
        }

            public GetOneResult<Book> DeleteByName(string id)
            {
            var result = new GetOneResult<Book>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<Book>.Filter.Eq("_id", objectId);
                var data = _collection.FindOneAndDelete(filter);
                result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"DeleteById {ex.Message}";
                result.Success = false;
            }
            return result;
        }
    }
} 
