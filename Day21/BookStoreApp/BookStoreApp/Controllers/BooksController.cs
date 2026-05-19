using BookStoreApp.Data;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository repo;

        public BooksController(IConfiguration config)
        {
            repo = new BookRepository(config.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            var books = repo.GetBooks();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            repo.AddBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = repo.GetBooks().FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            repo.UpdateBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repo.DeleteBook(id);
            return RedirectToAction("Index");
        }

    }
}
