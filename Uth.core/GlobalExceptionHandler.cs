using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Uth.core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UthException ex)
            {
                await HandleExceptionAsync(httpContext, (int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch
            {

                await HandleExceptionAsync(httpContext, (int)HttpStatusCode.InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, int statusCode, string message = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var responseString = JsonConvert.SerializeObject(new
            {
                message
            });

            return context.Response.WriteAsync(responseString);
        }
    }
}