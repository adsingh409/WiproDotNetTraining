using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repo;

        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

        // ✅ GET: Books
        public IActionResult Index()
        {
            var books = _repo.GetBooksWithAuthors();
            return View(books);
        }

        // ✅ GET: Create Page
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Save Book
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _repo.Add(book);
            _repo.Save();
            return RedirectToAction("Index");
        }
    }
}
