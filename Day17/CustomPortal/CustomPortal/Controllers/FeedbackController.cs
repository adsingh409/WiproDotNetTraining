using CustomPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomPortal.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(Feedback model)
        {
            return View("Success");
        }

    }
}
