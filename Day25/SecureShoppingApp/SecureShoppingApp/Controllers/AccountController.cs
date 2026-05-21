using BCrypt.Net;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SecureShoppingApp.Data;
using SecureShoppingApp.Models;
using System.Security.Claims;


namespace SecureShoppingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Register(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            // Role assign
            if (user.Email.Contains("admin"))
                user.Role = "Admin";
            else
                user.Role = "Customer";

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

                var identity = new ClaimsIdentity(claims, "CookieAuth");

                await HttpContext.SignInAsync("CookieAuth",
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        
        public IActionResult AccessDenied()
        {
            return Content("Access Denied ❌");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }

    }
}
