using System.ComponentModel.DataAnnotations;

namespace CustomPortal.Models
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Min 6 characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
