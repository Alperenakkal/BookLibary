
using BookLibary.Api.Repositories;
using BookLibary.Api.Models;

public interface IBookRepository<T> where T: class
    {

        Task<T> GetByNameAsync(string name);
        Task<T> InsertOneAsync(Book book);
        Task<GetManyResult<Book>> GetAllAsync();
        GetOneResult<Book> DeleteByName(string name);
        
    }