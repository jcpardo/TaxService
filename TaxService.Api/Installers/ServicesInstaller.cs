using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Api.Helpers;
using TaxService.Api.Helpers.AutoMapper;
using TaxService.Api.Interfaces;

namespace TaxService.Api.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            services.AddTransient<ITaxService, Services.TaxService>();
            services.AddTransient<IQueryHelper, QueryHelper>();
            services.AddTransient<IHttpClientConfigurationHelper, HttpClientConfigurationHelper>();
            services.AddTransient<AutoMapperUtility>();
        }
    }
}