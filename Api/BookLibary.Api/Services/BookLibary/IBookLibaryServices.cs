using BookLibary.Api.Dtos;

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
