using Microsoft.AspNetCore.Mvc;
using CustomPortal.Models;

namespace CustomPortal.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                return View("Success");
            }
            return View(model);
        }
    }
}