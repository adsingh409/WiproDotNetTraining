using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day_10_Assignment3_Razorpage.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public string NewItem { get; set; }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(NewItem))
            {
                ItemsModel.Items.Add(NewItem);
            }
            return RedirectToPage("Items");
        }
    }

}
