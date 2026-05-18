using Microsoft.AspNetCore.Mvc;

namespace ECommerceAdvancedRoutingApp.Controllers
{
    public class UsersController : Controller
    {
        // /Users/aditya/Orders
        public IActionResult Orders(string username)
        {
            ViewBag.Username = username;
            return View();
        }

    }
}
