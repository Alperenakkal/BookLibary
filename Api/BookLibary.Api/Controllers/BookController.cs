using Microsoft.AspNetCore.Mvc;
using BookLibary.Api.Services;
using BookLibary.Api.Models;
using BookLibary.Api.Services.AuthServices;

namespace BookLibary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var result = _bookService.GetAllBooks();
            if (result.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            var result = await _bookService.GetBookByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Entity);
            }
            return NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            var result = await _bookService.CreateBookAsync(book);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(string id, [FromBody] Book book)
        {
            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook.Entity == null)
            {
                return NotFound();
            }

            var result = await _bookService.UpdateBookAsync(id, book);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (result.Success)
            {
                return NoContent();
            }
            return NotFound(result.Message);
        }
    }
}
