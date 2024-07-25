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
    }
}
