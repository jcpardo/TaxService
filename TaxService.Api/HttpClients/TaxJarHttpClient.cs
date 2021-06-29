using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxService.Api.Entities.TaxJar.RequestForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForLocation;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.ResquestForLocation;
using TaxService.Api.Exceptions;
using TaxService.Api.Interfaces;

namespace TaxService.Api.HttpClients
{
    public class TaxJarHttpClient : ITaxJarHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IQueryHelper _queryHelper;

        public TaxJarHttpClient(HttpClient httpClient, IQueryHelper queryHelper, IHttpClientConfigurationHelper configurationHelper)
        {
            _httpClient = httpClient;
            _queryHelper = queryHelper;

            var taxJarConfig = configurationHelper.GetConfiguration(nameof(TaxJarHttpClient));

            _httpClient.BaseAddress = new Uri(taxJarConfig.BaseAddress);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", taxJarConfig.ApiKey);
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<TaxJarResponseForOrder> CalculateTaxesForOrderAsync(TaxJarRequestForOrder parameters)
        {
            var uri = "v2/taxes";
            var response = await _httpClient.PostAsJsonAsync(uri, parameters);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpCustomException(response.StatusCode, response.ReasonPhrase);
            }
            return await response.Content.ReadFromJsonAsync<TaxJarResponseForOrder>();
        }

        public async Task<TaxJarResponseForLocation> CalculateTaxForLocationAsync(TaxJarRequestForLocation parameters)
        {
            var uri = _queryHelper.AppendObjectToQueryString("v2/rates", parameters);
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpCustomException(response.StatusCode, response.ReasonPhrase);
            }
            return await response.Content.ReadFromJsonAsync<TaxJarResponseForLocation>();
        }

    }
}