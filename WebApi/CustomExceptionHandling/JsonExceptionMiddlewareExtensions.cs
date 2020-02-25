using Microsoft.AspNetCore.Builder;

namespace WebApi.CustomExceptionHandling
{
    public static class JsonExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomJsonExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JsonExceptionMiddleware>();
        }
    }
}
