using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Day16_WebApplication1
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Request: " + context.Request.Path);

            await _next(context);

            Console.WriteLine("Response Done");
        }
    }
}
