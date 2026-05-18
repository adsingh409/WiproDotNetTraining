using Microsoft.AspNetCore.Mvc;

namespace ECommerceAdvancedRoutingApp.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index(bool isLoggedIn)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Orders", "Users");
            }

            return Content("Proceed to Checkout");
        }

    }
}
