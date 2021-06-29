using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Interfaces;
using TaxService.Helpers;

namespace TaxService.Installers
{
    public static class ServicesInstaller
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddTransient<ITaxService, Services.TaxService>();
            services.AddTransient<IQueryHelper, QueryHelper>();
            services.AddTransient<IHttpClientConfigurationHelper, HttpClientConfigurationHelper>();
        }
    }
}