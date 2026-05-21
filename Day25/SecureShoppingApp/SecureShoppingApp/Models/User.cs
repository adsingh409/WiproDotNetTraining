using System.ComponentModel.DataAnnotations;

namespace SecureShoppingApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        

        public string Role { get; set; } // Admin / Customer
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W]).+$",
        ErrorMessage = "Password must contain uppercase, number, special char")]
        public string PasswordHash { get; set; }


    }

}
