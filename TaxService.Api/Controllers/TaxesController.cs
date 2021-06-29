using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxService.Api.Dtos.RequestForLocation;
using TaxService.Api.Dtos.RequestForOrder;
using TaxService.Api.Dtos.ResponseForLocation;
using TaxService.Api.Dtos.ResponseForOrder;
using TaxService.Api.Interfaces;

namespace TaxService.Api.Controllers
{
    [Route("api/taxes")]
    [Produces("application/json")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxesController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpGet("location")]
        [ProducesResponseType(typeof(TaxResponseForLocationDto), 200)]
        public async Task<IActionResult> Get([FromQuery] TaxRequestForLocationDto parameters)
        {
            var response = await _taxService.GetTaxForLocationAsync(parameters);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        // POST api/<TaxesController>
        [ProducesResponseType(typeof(TaxResponseForOrderDto),200)]
        [HttpPost("order")]
        public async Task<IActionResult> Post([FromBody] TaxRequestForOrderDto parameters)
        {
            var response = await _taxService.GetTaxForOrderAsync(parameters);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }



        
       
    }
}
