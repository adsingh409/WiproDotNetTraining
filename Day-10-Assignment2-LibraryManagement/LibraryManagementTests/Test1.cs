using LibraryManagement;
//using Day-10-Assignment2-LibraryManagement;
//using Microsoft.Extensions.DependencyModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;





namespace LibraryManagementTests
{
    [TestClass]
    public class Test1
    {
        //
        //private Microsoft.Extensions.DependencyModel.Library library = null!;
        private Library library = null;

        [TestInitialize]
        public void Setup()
        {
           // library = new Microsoft.Extensions.DependencyModel.Library();
           library = new Library();

        }

        [TestMethod]
        public void Test_Add_Book()
        {
            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };
            library.AddBook(book);

            Assert.AreEqual(1, library.Books.Count);
        }

        [TestMethod]
        public void Test_Register_Borrower()
        {
            var borrower = new Borrower { Name = "Aditya", LibraryCardNumber = "001" };
            library.RegisterBorrower(borrower);

            Assert.AreEqual(1, library.Borrowers.Count);
        }

        [TestMethod]
        public void Test_Borrow_Book()
        {
            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };
            var borrower = new Borrower { Name = "Aditya", LibraryCardNumber = "001" };

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("123", "001");

            Assert.IsTrue(book.IsBorrowed);
            Assert.AreEqual(1, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void Test_Return_Book()
        {
            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };
            var borrower = new Borrower { Name = "Aditya", LibraryCardNumber = "001" };

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("123", "001");
            library.ReturnBook("123", "001");

            Assert.IsFalse(book.IsBorrowed);
            Assert.AreEqual(0, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void Test_View()
        {
            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };
            var borrower = new Borrower { Name = "Aditya", LibraryCardNumber = "001" };

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            Assert.AreEqual(1, library.ViewBooks().Count);
            Assert.AreEqual(1, library.ViewBorrowers().Count);
        }
    }

}
