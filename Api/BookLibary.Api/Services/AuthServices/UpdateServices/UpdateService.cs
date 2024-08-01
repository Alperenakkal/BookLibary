using BookLibary.Api.Models;
using BookLibary.Api.Repositories;

namespace BookLibary.Api.Services.AuthServices.UpdateServices
{
	public class UpdateService : IUpdateService
	{
		private readonly IRepository<User> _updateRepository;
		public GetManyResult<User> GetAllUsers()
		{
			return _updateRepository.GetAll();
		}
		public UpdateService(IRepository<User> updateRepository)
		{
			_updateRepository = updateRepository;
		}
		public Task<GetOneResult<User>> GetUserByIdAsync(string id)
		{
			return _updateRepository.GetByIdAsync(id);
		}
		public async Task<GetOneResult<User>> UpdateUserAsync(string id, User user)
		{
			return await _updateRepository.ReplaceOneAsync(user, id);
		}
		
	}
}