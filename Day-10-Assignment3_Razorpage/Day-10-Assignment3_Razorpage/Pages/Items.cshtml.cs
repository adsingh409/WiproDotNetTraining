using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day_10_Assignment3_Razorpage.Pages
{
    public class ItemsModel : PageModel
    {
        // List of items
        public static List<string> Items = new List<string>
        {
            "Apple",
            "Banana",
            "Mango"
        };

        public void OnGet()
        {
        }
    }
}
