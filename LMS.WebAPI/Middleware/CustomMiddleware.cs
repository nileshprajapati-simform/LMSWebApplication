using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LMS.WebAPI.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Custom logic before the next middleware/component
            await _next(context);
            // Custom logic after the next middleware/component
        }
    }
}