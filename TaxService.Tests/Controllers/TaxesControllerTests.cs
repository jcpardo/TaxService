using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxService.Api.Entities.TaxJar.RequestForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForLocation;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;

namespace TaxService.Tests.Controllers
{
    [TestClass]
    public class TaxesControllerTests
    {
        HttpClient httpclient;
        Uri requestUri;

        [TestInitialize]
        public void Init()
        {
            httpclient = new HttpClient();

            requestUri = new Uri("https://localhost:5001/api/taxes/");
            httpclient.BaseAddress = requestUri;
            httpclient.DefaultRequestHeaders.Accept.Clear();
            httpclient.DefaultRequestHeaders.Connection.Add("keep-alive");
            httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpclient.DefaultRequestHeaders.Add("apiKey",
                "J1hGB4GsnqJ5k50sJ46Abx5hssKIE2wWMgdP3NlsTu7n7Dni87b7KhZBm6gM");
        }

        [TestCleanup]
        public void Clean()
        {
            if (httpclient != null)
                httpclient.Dispose();
        }

        [TestMethod]
        public async Task Get_Taxes_For_Location_Test()
        {
            var expectedResponse = new TaxJarResponseForLocation
            {
                rate = new RateResponse
                {
                    city = "CORAL GABLES",
                    city_rate = "0.0",
                    combined_district_rate = "0.0",
                    combined_rate = "0.07",
                    country = "US",
                    country_rate = "0.0",
                    county = "MIAMI-DADE",
                    county_rate = "0.01",
                    freight_taxable = false,
                    state = "FL",
                    state_rate = "0.06",
                    zip = "33133"
                }
            };

            var result = await httpclient.GetAsync("location?zip=33133");
            var response = await result.Content.ReadFromJsonAsync<TaxJarResponseForLocation>();
            Assert.Equals(expectedResponse, response);
        }

        [TestMethod]
        public async Task Post_Taxes_For_Order_Test()
        {
            var request = new TaxJarRequestForOrder
            {

                from_country = "US",
                from_zip = "92093",
                from_state = "CA",
                from_city = "La Jolla",
                from_street = "9500 Gilman Drive",
                to_country = "US",
                to_zip = "90002",
                to_state = "CA",
                to_city = "Los Angeles",
                to_street = "1335 E 103rd St",
                amount = 15,
                shipping = 1.5,
                nexus_addresses = new List<NexusAddressRequest>
                {
                    new NexusAddressRequest
                    {
                        id = "Main Location",
                        country = "US",
                        zip = "92093",
                        state = "CA",
                        city = "La Jolla",
                        street = "9500 Gilman Drive"
                    }
                },
                line_items = new List<LineItemRequest>
                {
                    new LineItemRequest
                    {
                        id = "1",
                        quantity = 1,
                        product_tax_code = "20010",
                        unit_price = 15,
                        discount = 0
                    }
                }
            };

            var expectedResponse = new TaxJarResponseForOrder
            {
                tax = new TaxResponse
                {
                    order_total_amount = 16.5,
                    shipping = 1.5,
                    taxable_amount = 15,
                    amount_to_collect = 1.43,
                    rate = 0.095,
                    has_nexus = true,
                    freight_taxable = false,
                    exemption_type = null,
                    tax_source = "destination",
                    jurisdictions = new JurisdictionsResponse
                    {
                        country = "US",
                        state = "CA",
                        county = "LOS ANGELES COUNTY",
                        city = "LOS ANGELES"
                    },
                    breakdown = new BreakdownResponse
                    {
                        taxable_amount = 15,
                        tax_collectable = 1.43,
                        combined_tax_rate = 0.095,
                        state_taxable_amount = 15,
                        state_tax_rate = 0.0625,
                        state_tax_collectable = 0.94,
                        county_taxable_amount = 15,
                        county_tax_rate = 0.01,
                        county_tax_collectable = 0.15,
                        city_taxable_amount = 0,
                        city_tax_rate = 0,
                        city_tax_collectable = 0,
                        special_district_taxable_amount = 15,
                        special_tax_rate = 0.0225,
                        special_district_tax_collectable = 0.34,
                        line_items = new List<LineItemResponse>
                        {
                            new LineItemResponse
                            {
                                id = "1",
                                taxable_amount = 15,
                                tax_collectable = 1.43,
                                combined_tax_rate = 0.095,
                                state_taxable_amount = 15,
                                state_sales_tax_rate = 0.0625,
                                state_amount = 0.94,
                                county_taxable_amount = 15,
                                county_tax_rate = 0.01,
                                county_amount = 0.15,
                                city_taxable_amount = 0,
                                city_tax_rate = 0,
                                city_amount = 0,
                                special_district_taxable_amount = 15,
                                special_tax_rate = 0.0225,
                                special_district_amount = 0.34
                            }

                        }
                    }
                }
            };

            var result = await httpclient.PostAsJsonAsync("order", request);

            var response = await result.Content.ReadFromJsonAsync<TaxJarResponseForOrder>();

            Assert.Equals(expectedResponse, response);
        }
    };
}
    