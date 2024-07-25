using BookLibary.Web.Dtos;
using BookLibary.Web.Models;
using BookLibary.Web.Repositories;

namespace BookLibary.Web.Services.BookLibaryServices
{
    public class BookLibaryServices : IBookLibaryServices
    {
        private readonly IRepository<Book> _repository;

        public BookLibaryServices(IRepository<Book> repository) => _repository = repository;
        public async Task CreateBookAsync(CreateBookDto model)
        {
            var book = new Book
            {
                Name = model.Name,
                Yazar = model.Yazar,
                Durum = model.Durum,
            };

            await _repository.CreateAsync(book);
        }

       

        public async Task DeleteBookAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(book);
        }

        public async Task<List<ResultBookDto>> GetAllBookAsync()
        {
            var books = await _repository.GetAllAsync();
            return books.Select(x => new ResultBookDto
            {
                Id = x.Id,
                Name = x.Name,
                Yazar = x.Yazar,
                Durum = x.Durum,

            }).ToList();
        }

        public async Task<GetByIdBookDto> GetByIdBookAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null)
            {
                return new GetByIdBookDto();
            }
            var oneBook = new GetByIdBookDto
            {
                Id = book.Id,
                Name = book.Name,
                Yazar = book.Yazar,
                Durum = book.Durum,
            };
            return oneBook;
        }

        public async Task UpdateBookAsync(UpdateBookDto model)
        {
            var book = await _repository.GetByIdAsync(model.Id);
            book.Name = model.Name;
            book.Yazar = model.Yazar;
            book.Durum = model.Durum;
            await _repository.UpdateAsync(book);

        }

     
    }
}
