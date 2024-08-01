using BookLibary.Api.Models;
using BookLibary.Api.Repositories;

namespace BookLibary.Api.Services.AuthServices.UpdateServices
{
	public interface IUpdateService
	{
		Task<GetOneResult<User>> GetUserByIdAsync(string id);
		Task<GetOneResult<User>> UpdateUserAsync(string id, User user);
	}
}
