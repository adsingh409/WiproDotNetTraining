using Microsoft.AspNetCore.Mvc;

namespace ECommerceAdvancedRoutingApp.Controllers
{
    public class ProductsController : Controller
    {
        // /Products/Electronics/1
        public IActionResult Details(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.Id = id;
            return View();
        }

        // /Products/Filter/Electronics/100-500
        public IActionResult Filter(string category, string priceRange)
        {
            ViewBag.Category = category;
            ViewBag.PriceRange = priceRange;
            return View();
        }
    }
}
