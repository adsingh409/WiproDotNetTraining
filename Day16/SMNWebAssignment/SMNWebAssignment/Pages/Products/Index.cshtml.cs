using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMNWebAssignment.Models;

namespace SMNWebAssignment.Pages.Products
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; }

        public  List<Product> Products = new List<Product>();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            Products.Add(NewProduct);
            return RedirectToPage();
        }
    }
}
