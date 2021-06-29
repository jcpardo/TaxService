using Microsoft.AspNetCore.Builder;
using TaxService.Api.Security;

namespace TaxService.Api.Extensions
{
    public static class ApiKeyMessageExtension
    {
        public static IApplicationBuilder UseApiKeyHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMessageMiddleware>();
        }
    }
}