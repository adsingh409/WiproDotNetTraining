using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CombinedApp.Models;

namespace CombinedApp.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        public IActionResult OnPost()
        {
            IndexModel.Items.Add(new Item { Name = Name });
            return RedirectToPage("Index");
        }
    }
}