using BookLibary.Api.Dtos.UserDto;
using BookLibary.Api.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserController(IUserServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto model)
        {
            if (model.UserName == null || model.UserName == "") { return BadRequest("UserName alanı zorunludur"); }
            if (model.Password == null || model.Password == "") { return BadRequest("Password alanı zorunludur"); }
            var user= await _services.CreateUserAsync(model);
            return Ok(user +"Bilgilerinizle başarılı bir şekilde kullanıcı oluşturuldu");
        }
    }
}
