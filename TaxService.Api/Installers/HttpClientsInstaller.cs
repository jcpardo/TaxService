using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Api.HttpClients;
using TaxService.Api.Interfaces;

namespace TaxService.Api.Installers
{
    public class HttpClientsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ITaxJarHttpClient, TaxJarHttpClient>();
        }
    }
}