using TaxService.Options;

namespace TaxService.Interfaces
{
    public interface IHttpClientConfigurationHelper
    {
        TaxProvidersOptions GetConfiguration(string clientName);
    }
}