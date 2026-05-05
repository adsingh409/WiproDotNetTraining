using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day16_WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API chal rahi hai 🚀";
        }
    }
}
