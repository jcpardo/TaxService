using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TaxService.Api.Interfaces;
using TaxService.Api.Options;

namespace TaxService.Api.Helpers
{
    public class HttpClientConfigurationHelper : IHttpClientConfigurationHelper
    {
        private readonly IConfiguration _configuration;

        public HttpClientConfigurationHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TaxProvidersOptions GetConfiguration(string clientName)
        {
            var taxProviders = new List<TaxProvidersOptions>();
            _configuration.GetSection("TaxProviders").Bind(taxProviders);

            return taxProviders.FirstOrDefault(x => x.Name == clientName);
        }
    }
}