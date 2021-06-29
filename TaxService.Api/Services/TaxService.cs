using System.Threading.Tasks;
using TaxService.Entities.TaxJar.RequestForOrder;
using TaxService.Entities.TaxJar.ResponseForLocation;
using TaxService.Entities.TaxJar.ResponseForOrder;
using TaxService.Entities.TaxJar.ResquestForLocation;
using TaxService.Interfaces;

namespace TaxService.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxJarHttpClient _taxJarHttpClient;
        public TaxService(ITaxJarHttpClient taxJarHttpClient)
        {
            _taxJarHttpClient = taxJarHttpClient;
        }

        public async Task<TaxJarResponseForOrder> GetTaxForOrderAsync(TaxJarRequestForOrder orderDetails)
        {
            return await _taxJarHttpClient.CalculateTaxesForOrderAsync(orderDetails);
        }

        public async Task<TaxJarResponseForLocation> GetTaxForLocationAsync(TaxJarRequestForLocation locationDetails)
        {
            return await _taxJarHttpClient.CalculateTaxForLocationAsync(locationDetails);
        }
    }
}