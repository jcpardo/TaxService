using System.Threading.Tasks;
using TaxService.Api.Dtos.RequestForLocation;
using TaxService.Api.Dtos.RequestForOrder;
using TaxService.Api.Dtos.ResponseForLocation;
using TaxService.Api.Dtos.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.RequestForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForLocation;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.ResquestForLocation;
using TaxService.Api.Helpers.AutoMapper;
using TaxService.Api.Interfaces;

namespace TaxService.Api.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxJarHttpClient _taxJarHttpClient;
        private readonly AutoMapperUtility _autoMapper;
        public TaxService(ITaxJarHttpClient taxJarHttpClient, AutoMapperUtility autoMapper)
        {
            _taxJarHttpClient = taxJarHttpClient;
            _autoMapper = autoMapper;
        }

        public async Task<TaxResponseForOrderDto> GetTaxForOrderAsync(TaxRequestForOrderDto orderDetails)
        {
            var mappedOrderDetails = new TaxJarRequestForOrder();
            _autoMapper.CopyDataFromModel(orderDetails, mappedOrderDetails);
            return  _autoMapper.GetModelFromData<TaxResponseForOrderDto, TaxJarResponseForOrder>(await _taxJarHttpClient.CalculateTaxesForOrderAsync(mappedOrderDetails));
        }

        public async Task<TaxResponseForLocationDto> GetTaxForLocationAsync(TaxRequestForLocationDto locationDetails)
        {
            var mappedLocationDetails = new TaxJarRequestForLocation();
            _autoMapper.CopyDataFromModel(locationDetails, mappedLocationDetails);
            return _autoMapper.GetModelFromData<TaxResponseForLocationDto, TaxJarResponseForLocation>(await _taxJarHttpClient.CalculateTaxForLocationAsync(mappedLocationDetails));
        }
    }
}