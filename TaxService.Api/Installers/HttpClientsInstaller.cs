using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxService.HttpClients;
using TaxService.Interfaces;

namespace TaxService.Installers
{
    public class HttpClientsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ITaxJarHttpClient, TaxJarHttpClient>();
        }
    }
}