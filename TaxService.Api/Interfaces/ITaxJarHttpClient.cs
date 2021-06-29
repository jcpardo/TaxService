using System.Threading.Tasks;
using TaxService.Entities.TaxJar.RequestForOrder;
using TaxService.Entities.TaxJar.ResponseForLocation;
using TaxService.Entities.TaxJar.ResponseForOrder;
using TaxService.Entities.TaxJar.ResquestForLocation;

namespace TaxService.Interfaces
{
    public interface ITaxJarHttpClient
    {
        Task<TaxJarResponseForOrder> CalculateTaxesForOrderAsync(TaxJarRequestForOrder parameters);
        Task<TaxJarResponseForLocation> CalculateTaxForLocationAsync(TaxJarRequestForLocation parameters);
    }
}