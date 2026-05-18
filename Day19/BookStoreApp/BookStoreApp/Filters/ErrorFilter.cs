using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStoreApp.Filters
{
    public class ErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = "Something went wrong!",
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
