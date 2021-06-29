using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TaxService.Exceptions;

namespace TaxService.Security
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private static ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpCustomException httpCustomException)
            {
                await HandleHttpCustomExceptionAsync(context, httpCustomException);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleHttpCustomExceptionAsync(HttpContext context, HttpCustomException ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException?.Message);

            var result = JsonConvert.SerializeObject(ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;
            return context.Response.WriteAsync(result);
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException?.Message);

            var result = JsonConvert.SerializeObject("An unexpected fault happened.");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}