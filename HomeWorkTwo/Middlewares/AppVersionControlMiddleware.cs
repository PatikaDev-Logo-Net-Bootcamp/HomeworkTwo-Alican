using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkTwo.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionControlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AppVersionControlMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var getCurrentVersion = new Version(_configuration.GetValue<string>("app-version"));
                var requestVersion = new Version(httpContext.Request.Headers["app-version"]);
                if ((requestVersion.CompareTo(getCurrentVersion) <= 0) ||
                    (httpContext.Request.Path =="api/[contoller]/login") 
                    || (httpContext.Request.Path == "api/[controller]/register"))
                {
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("Yetkisiz Giriş!!!");
                }

            }
            catch (Exception e)
            {
                await HandleExceptionMiddleware(httpContext, e);
            }
        }
        private static async Task HandleExceptionMiddleware(HttpContext httpContext,Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync($"Unauthorized! Details: {exception.Message}");
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AppVersionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppVersionControlMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionControlMiddleware>();
        }
    }
}
