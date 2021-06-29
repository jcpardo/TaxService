using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace TaxService.Api.Security
{
    public class ApiKeyMessageMiddleware
    {
        private readonly string _apiKey;
        private readonly RequestDelegate _next;

        public ApiKeyMessageMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apiKey = configuration.GetSection("APIKey").Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var validKey = false;

            if (context.Request.Headers.ContainsKey("apiKey"))
            {
                if (context.Request.Headers["apiKey"].Equals(_apiKey))
                {
                    validKey = true;
                }
            }

            if (!validKey)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid Key");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}