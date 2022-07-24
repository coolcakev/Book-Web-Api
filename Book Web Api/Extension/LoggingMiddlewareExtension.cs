using Book_Web_Api.Midelwares;
using Microsoft.AspNetCore.Builder;

namespace Book_Web_Api.Extension
{
    public static class LoggingMiddlewareExtension
    {
        public static void UseLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
