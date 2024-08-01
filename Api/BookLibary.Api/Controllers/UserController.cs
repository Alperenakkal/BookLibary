using Azure.Core;
using BookLibary.Api.Dtos;
using BookLibary.Api.Models;
using BookLibary.Api.Models.Request.UserRequest;
using BookLibary.Api.Models.Response.UserResponse;
using BookLibary.Api.Services.AuthServices.LoginServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BookLibary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _service;
        private string hashPassword;

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
            SHA1 sha = new SHA1CryptoServiceProvider();

            hashPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(model.Password)));

            if (model == null || model.UserName == "" || model.Password == "")
            { return BadRequest("İlgili alanlar boş bırakılmaz"); }
            User user = await _service.GetByNameAsync(model.UserName);
            if (user == null) { return BadRequest("Girmis olduğunuz kullanici adi bilgisi yanlistir"); }
            if (user.Password != hashPassword) { return BadRequest("Şifre yanlis"); }
            return Ok("Giris islemi basarili");
        }
        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginUserAsync([FromBody] LoginRequest request)
        {
            var result = await _service.LoginUserAsync(request);

            return result;
        }

    }
}