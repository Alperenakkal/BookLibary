using BookLibary.Api.Models;
using BookLibary.Api.Repositories;

namespace BookLibary.Api.Services.AuthServices
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public GetManyResult<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Task<GetOneResult<Book>> GetBookByIdAsync(string id)
        {
            return _bookRepository.GetByIdAsync(id);
        }

        public Task<GetOneResult<Book>> CreateBookAsync(Book book)
        {
            return _bookRepository.InsertOneAsync(book);
        }

        public Task<GetOneResult<Book>> UpdateBookAsync(string id, Book book)
        {
            return _bookRepository.ReplaceOneAsync(book, id);
        }

        public Task<GetOneResult<Book>> DeleteBookAsync(string id)
        {
            return _bookRepository.DeleteByIdAsync(id);
        }
    }
}
