using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TaxService.Interfaces;
using TaxService.Options;

namespace TaxService.Helpers
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