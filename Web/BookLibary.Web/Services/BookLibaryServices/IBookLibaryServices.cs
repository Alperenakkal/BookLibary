using BookLibary.Web.Dtos;

namespace BookLibary.Web.Services.BookLibaryServices
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
