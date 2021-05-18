using Api1.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Application.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("taxaJuros")]
    public class InterestRatesController : ControllerBase
    {
        /// <summary>
        /// Get interest rates 
        /// </summary>
        /// <returns>double</returns>
        /// <returns>A interest rates</returns>
        /// <response code="200">Returns interest rates</response>
        [HttpGet]
        [ResponseCache(Duration = 600)]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public double Get()
        {
            var fees = new InterestRates(1.0 / 100);

            return fees.Value;
        }
    }
}
