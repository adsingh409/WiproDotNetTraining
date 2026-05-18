using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View();
        }

    }
}
