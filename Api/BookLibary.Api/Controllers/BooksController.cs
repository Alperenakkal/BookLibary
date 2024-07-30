using BookLibary.Api.Dtos.BookDto;
using BookLibary.Api.Services.BookLibary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BookLibary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookLibaryServices _services;

        public BooksController(IBookLibaryServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var value = await _services.GetAllBookAsync();
            if(value.Count==0)
            {
                return NotFound("Hiç Kitap Bulunamadı .");
            }
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBook(int id)
        {
            var value = await _services.GetByIdBookAsync(id);
            if (value.Id==0) { return NotFound("Kitap Bulunamadı"); }
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto model)
        {
            if (model.Name == null || model.Name=="") { return BadRequest("Isim yazmak zorundasınız"); }
            if(model.Yazar==null || model.Yazar=="") { return BadRequest("Yazar yazmak zorundasınız"); }
      
            await _services.CreateBookAsync(model);


            return Ok("Kitabınız başarılı bir şekilde oluşturuldu.");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBook(UpdateBookDto model)
        {
            await _services.UpdateBookAsync(model);
            return Ok("Kitabınız başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _services.DeleteBookAsync(id);
            return Ok("Kitabınız başarılı bir şekilde silindi");
        }
    }
}
