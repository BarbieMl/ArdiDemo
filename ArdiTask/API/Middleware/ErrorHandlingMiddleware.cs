using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new {error = "an error has occured while processing your request" });
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;
            return httpContext.Response.WriteAsync(result);
        }
    }
}
