using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        [Range(1, 1000)]
        public int Price { get; set; }
    }
}
