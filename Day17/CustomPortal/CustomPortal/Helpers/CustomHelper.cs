using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomPortal.Helpers
{
    public static class CustomHelper
    {
        public static IHtmlContent CustomInput(this IHtmlHelper html, string name)
        {
            return new HtmlString($"<input type='text' name='{name}' placeholder='Enter {name}' class='form-control' />");
        }
    }
}
