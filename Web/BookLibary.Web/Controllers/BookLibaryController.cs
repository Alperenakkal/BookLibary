using BookLibary.Web.Dtos;
using BookLibary.Web.Services.BookLibaryServices;
using Microsoft.AspNetCore.Mvc;

namespace BookLibary.Web.Controllers
{
    public class BookLibaryController : Controller
    {
        private readonly IBookLibaryServices _services;

        public BookLibaryController(IBookLibaryServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var value= await _services.GetAllBookAsync();

            return View(value);
        }
        public async Task<IActionResult> Edit(int id) 
        {
            var book = await _services.GetByIdBookAsync(id);
           

            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBookDto model)
        {
            await _services.UpdateBookAsync(model);
            return RedirectToAction("Index");
        }
        public IActionResult Create() 
        { 
            return View(); 
        
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto model)
        {
          
            await _services.CreateBookAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteBookAsync(id);

            return RedirectToAction("Index","BookLibary");
        }
       

    }
}
