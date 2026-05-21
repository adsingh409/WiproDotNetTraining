using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureAppJwt.Controllers
{
    
    
        [ApiController]
        [Route("api/[controller]")]
        public class ProtectedController : ControllerBase
        {
            [Authorize]
            [HttpGet("user")]
            public IActionResult UserAccess()
            {
                return Ok("User Access Granted");
            }

            [Authorize(Roles = "Admin")]
            [HttpGet("admin")]
            public IActionResult AdminAccess()
            {
                return Ok("Admin Access Granted");
            }
        }

    }

