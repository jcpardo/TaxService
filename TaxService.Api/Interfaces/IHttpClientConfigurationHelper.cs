using TaxService.Api.Options;

namespace TaxService.Api.Interfaces
{
    public interface IHttpClientConfigurationHelper
    {
        TaxProvidersOptions GetConfiguration(string clientName);
    }
}