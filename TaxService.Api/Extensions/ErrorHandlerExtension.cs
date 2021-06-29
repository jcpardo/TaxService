using Microsoft.AspNetCore.Builder;
using TaxService.Api.Security;

namespace TaxService.Api.Extensions
{
    public static class ErrorHandlerExtension
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}