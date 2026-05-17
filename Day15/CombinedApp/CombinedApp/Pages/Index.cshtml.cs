using Microsoft.AspNetCore.Mvc.RazorPages;
using CombinedApp.Models;

namespace CombinedApp.Pages
{
    public class IndexModel : PageModel
    {
        public static List<Item> Items = new List<Item>()
        {
            new Item { Name = "Item 1" },
            new Item { Name = "Item 2" }
        };

        public List<Item> ItemList { get; set; }

        public void OnGet()
        {
            ItemList = Items;
        }
    }
}