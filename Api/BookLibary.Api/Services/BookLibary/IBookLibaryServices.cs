using BookLibary.Api.Dtos.BookDto;

namespace BookLibary.Api.Services.BookLibary
{
    public interface IBookLibaryServices
    {
        Task<List<ResultBookDto>> GetAllBookAsync();
        Task<GetByIdBookDto> GetByIdBookAsync(int id);
        Task CreateBookAsync(CreateBookDto model);
        Task UpdateBookAsync(UpdateBookDto model);
        Task DeleteBookAsync(int id);

    }
}
