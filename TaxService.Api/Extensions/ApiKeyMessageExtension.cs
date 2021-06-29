using Microsoft.AspNetCore.Builder;
using TaxService.Security;

namespace TaxService.Extensions
{
    public static class ApiKeyMessageExtension
    {
        public static IApplicationBuilder UseApiKeyHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMessageMiddleware>();
        }
    }
}