using Book_Web_Api.Managers.Intrefaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_Web_Api.Midelwares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public LoggingMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var httpMethod = httpContext.Request.Method;
            var requestHeaders = httpContext.Request.Headers;
            var requesQuery = httpContext.Request.Query;


            _logger.LogInfo($"Http method : {httpMethod}");
            _logger.LogInfo($"Request Headers : {JsonSerializer.Serialize(requestHeaders)}");
            _logger.LogInfo($"Request Query : {JsonSerializer.Serialize(requesQuery)}");

            using (var mem = new MemoryStream())
            using (var reader = new StreamReader(mem))
            {
                await httpContext.Request.Body.CopyToAsync(mem);
                httpContext.Request.Body = mem;

                mem.Seek(0, SeekOrigin.Begin);
                var body = await reader.ReadToEndAsync();
                mem.Seek(0, SeekOrigin.Begin);

                // Do something
                _logger.LogInfo($"Request Body : {body}");
                await _next(httpContext);
            }



        }


    }
}
