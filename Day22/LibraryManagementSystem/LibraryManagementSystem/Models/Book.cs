namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }

    }
}
