using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxService.Entities.TaxJar.RequestForOrder;
using TaxService.Entities.TaxJar.ResponseForLocation;
using TaxService.Entities.TaxJar.ResponseForOrder;
using TaxService.Entities.TaxJar.ResquestForLocation;
using TaxService.Interfaces;


namespace TaxService.Controllers
{
    [Route("api/taxes")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxesController(ITaxService taxService)
        {
            _taxService = taxService;
        }

       
        [HttpGet("location")]
        [ProducesResponseType(typeof(TaxJarResponseForLocation), 200)]
        public async Task<IActionResult> Get([FromQuery] TaxJarRequestForLocation parameters)
        {
            var response = await _taxService.GetTaxForLocationAsync(parameters);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        // POST api/<TaxesController>
        [ProducesResponseType(typeof(TaxJarResponseForOrder),200)]
        [HttpPost("order")]
        public async Task<IActionResult> Post([FromBody] TaxJarRequestForOrder parameters)
        {
            var response = await _taxService.GetTaxForOrderAsync(parameters);// call a tax service //_taxJarHttpClient.Post(parameters);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }



        
       
    }
}
