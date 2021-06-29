using System.Threading.Tasks;
using TaxService.Api.Dtos.RequestForLocation;
using TaxService.Api.Dtos.RequestForOrder;
using TaxService.Api.Dtos.ResponseForLocation;
using TaxService.Api.Dtos.ResponseForOrder;

namespace TaxService.Api.Interfaces
{
    public interface ITaxService
    {
        Task<TaxResponseForOrderDto> GetTaxForOrderAsync(TaxRequestForOrderDto orderDetails);
        Task<TaxResponseForLocationDto> GetTaxForLocationAsync(TaxRequestForLocationDto locationDetails);
    }
}