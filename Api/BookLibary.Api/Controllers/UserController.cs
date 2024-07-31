using BookLibary.Api.Models;
using BookLibary.Api.Services.AuthServices.LoginServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _service;

        public UserController(ILoginService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            string username = await _service.GetByNameAsync(name);
            if (username == null) { return NotFound("Kullanıcı bulunamadi"); }
            return Ok(username);
        }

    }
}
