using Microsoft.AspNetCore.Mvc;
using SecureAppJwt.Models;
using SecureAppJwt.Services;

namespace SecureAppJwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService = new TokenService();

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            if (user.Username == "admin" && user.Password == "123")
            {
                user.Role = "Admin";
                var token = _tokenService.GenerateToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
