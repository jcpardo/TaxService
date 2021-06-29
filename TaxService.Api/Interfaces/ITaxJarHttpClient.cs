using System.Threading.Tasks;
using TaxService.Api.Entities.TaxJar.RequestForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForLocation;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.ResquestForLocation;

namespace TaxService.Api.Interfaces
{
    public interface ITaxJarHttpClient
    {
        Task<TaxJarResponseForOrder> CalculateTaxesForOrderAsync(TaxJarRequestForOrder parameters);
        Task<TaxJarResponseForLocation> CalculateTaxForLocationAsync(TaxJarRequestForLocation parameters);
    }
}