using BookLibary.Api.Models;
using BookLibary.Api.Repositories;
using BookLibary.Api.Services.AuthServices;
using BookLibary.Api.Services.AuthServices.UpdateServices;
using Microsoft.AspNetCore.Mvc;

namespace BookLibary.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UpdateController : ControllerBase
	{
		private readonly IUpdateService _updateService;
		public UpdateController(IUpdateService updateService)
		{
			_updateService = updateService;
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
		{
			var existingUser = await _updateService.GetUserByIdAsync(id);
			if (existingUser.Entity == null)
			{
				return NotFound();
			}

			var result = await _updateService.UpdateUserAsync(id, user);
			if (result.Success)
			{
				return NoContent();
			}
			return BadRequest(result.Message);
		}
	}
}
