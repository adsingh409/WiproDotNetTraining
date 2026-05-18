using ECommerceAdvancedRoutingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceAdvancedRoutingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard(string role)
        {
            if (role == "admin")
                return RedirectToAction("AdminDashboard");

            return RedirectToAction("UserDashboard");
        }

        public IActionResult AdminDashboard()
        {
            return Content("Welcome Admin");
        }

        public IActionResult UserDashboard()
        {
            return Content("Welcome User");
        }
        public IActionResult Index()
        {
            return Content("Welcome to Home Page");
        }
    }
}
