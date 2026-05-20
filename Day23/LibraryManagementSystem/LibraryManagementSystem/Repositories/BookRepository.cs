using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;



using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooksWithAuthors()
        {
            return _context.Books.Include(b => b.Author).ToList();
        }
    }
}
