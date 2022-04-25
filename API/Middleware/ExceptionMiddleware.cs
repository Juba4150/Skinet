using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this._env = env;
            this._logger = logger;
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                httpContext.Response.ContentType="application/json";
                httpContext.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                var response=_env.IsDevelopment()
                ? new ApiExceptionResponce((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace.ToString())
                : new ApiExceptionResponce((int)HttpStatusCode.InternalServerError);
                var jsonOptions=new JsonSerializerOptions{ PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
                var jsonResponse =JsonSerializer.Serialize(response,jsonOptions);
                await httpContext.Response.WriteAsync(jsonResponse);
            }
        }
    }
}