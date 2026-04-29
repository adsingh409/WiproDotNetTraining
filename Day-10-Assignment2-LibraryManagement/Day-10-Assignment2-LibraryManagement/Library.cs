using System;
using System.Collections.Generic;
using System.Linq;


namespace LibraryManagement

{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Borrower> Borrowers { get; set; } = new List<Borrower>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
        }

        public void BorrowBook(string isbn, string cardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == cardNumber);

            if (book != null && borrower != null && !book.IsBorrowed)
            {
                book.IsBorrowed = true;
                borrower.BorrowedBooks.Add(book);
            }
        }

        public void ReturnBook(string isbn, string cardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == cardNumber);

            if (book != null && borrower != null && book.IsBorrowed)
            {
                book.IsBorrowed = false;
                borrower.BorrowedBooks.Remove(book);
            }
        }

        public List<Book> ViewBooks()
        {
            return Books;
        }

        public List<Borrower> ViewBorrowers()
        {
            return Borrowers;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; set; }
    }

    public class Borrower
    {
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    }

}
    



        
    
