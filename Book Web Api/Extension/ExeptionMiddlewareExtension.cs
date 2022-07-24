using Book_Web_Api.Midelwares;
using Microsoft.AspNetCore.Builder;

namespace Book_Web_Api.Extension
{
    public static  class ExeptionMiddlewareExtension
    {
        public static void UseExeptionHandle(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomErrorHelndleMiddleware>();
        }
    }
}
