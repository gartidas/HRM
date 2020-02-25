using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.CustomExceptionHandling
{
    public class JsonExceptionMiddleware
    {
        private readonly RequestDelegate _httpRequestHandler;
        private readonly ILogger<JsonExceptionMiddleware> _logger;

        public JsonExceptionMiddleware(RequestDelegate httpRequestHandler, ILogger<JsonExceptionMiddleware> logger)
        {
            _httpRequestHandler = httpRequestHandler;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _httpRequestHandler(httpContext);
            }
            catch (Exception ex)
            {
                var code = HttpStatusCode.InternalServerError;
                var result = string.Empty;

                if (ex is NullReferenceException)
                {
                    if (ex.Source == "WebApi")
                    {
                        code = HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new { error = "Request is in bad format" });
                    }
                }

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)code;

                if (code == HttpStatusCode.InternalServerError)
                    _logger.LogError(ex, string.Empty);

                await httpContext.Response.WriteAsync(result);
            }
        }
    }
}
