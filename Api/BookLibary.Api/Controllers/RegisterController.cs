using BookLibary.Api.Dtos.UserDto;
using BookLibary.Api.Services.AuthServices.RegisterServices;
using Microsoft.AspNetCore.Mvc;

namespace BookLibary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterDto model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _registerService.Register(model);

            if (result == "Kullanılmış Kullanıcı Adı" || result == "Kullanılmış Email")
            {
                return BadRequest(new { Message = result });
            }

            return Ok(new { Message = "Kayıt başarılı" });
        }


            
        }



    }

