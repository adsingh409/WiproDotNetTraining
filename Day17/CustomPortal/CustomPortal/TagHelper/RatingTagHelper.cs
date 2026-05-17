using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomPortal.TagHelpers
{
    [HtmlTargetElement("rating-stars")]
    public class RatingTagHelper : TagHelper
    {
        public int Stars { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            for (int i = 0; i < Stars; i++)
            {
                output.Content.AppendHtml("⭐");
            }
        }
    }
}