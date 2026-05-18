using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStoreApp.Filters
{

    public class LoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Request Started: " + context.HttpContext.Request.Path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Request Finished");
        }
    }
}
