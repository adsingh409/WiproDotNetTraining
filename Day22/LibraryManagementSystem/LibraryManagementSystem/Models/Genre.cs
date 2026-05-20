namespace LibraryManagementSystem.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }

    }
}
