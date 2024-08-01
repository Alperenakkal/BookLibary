using BookLibary.Api.Dtos;
using BookLibary.Api.Models;
using BookLibary.Api.Models.Request.UserRequest;
using BookLibary.Api.Models.Response.UserResponse;
using BookLibary.Api.Services.AuthServices.LoginServices;
using Microsoft.AspNetCore.Authorization;
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
            User username = await _service.GetByNameAsync(name);
            if (username == null) { return NotFound("Kullanıcı bulunamadi"); }
            return Ok(username);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto model)
        {
            if (model == null || model.UserName == "" || model.Password == "")
            { return BadRequest("İlgili alanlar boş bırakılmaz"); }
            User user = await _service.GetByNameAsync(model.UserName);
            if (user == null) { return BadRequest("Girmis olduğunuz kullanici adi bilgisi yanlistir"); }
            if (user.Password != model.Password) { return BadRequest("Şifre yanlis"); }
            return Ok("Giris islemi basarili");
        }
        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginUserAsync([FromBody] LoginRequest request)
        {
            var result = await _service.LoginUserAsync(request);

            return result;
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutUserAsync();
            return Ok(new { message = "User logged out successfully." });
        }


    }
}