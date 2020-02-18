using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Training.Middleware
{
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers["Authorization"] == "langit biru")
            {
                await _next(context);
                return;
            }
            var text = "Not Authorize";

            var data = System.Text.Encoding.UTF8.GetBytes(text);
            await context.Response.Body.WriteAsync(data, 0, data.Length);
            //Console.WriteLine("Not Authorize");
        }
    }

    public static class AuthMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthMiddleware>();
        }
    }
}
