using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Api2.Application.Repositories;
using Api2.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Api2.Application.Controllers
{
    [Produces("application/json")]
    [Route("calculajuros")]
    public class InterestRatesCalculateController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public decimal Get(
            [FromQuery(Name = "valorinicial")] decimal initialValue,
            [FromQuery(Name = "meses")] int months,
            [FromServices] IServicesApiInterestsRates apiInterest,
            [FromServices] IConfiguration configuration)
        {
            string baseUrlApi = configuration.GetValue<string>("Integrations:ApiInterestsRates");
            var fee = apiInterest.FindValueInterestRates(baseUrlApi);

            var recipe = initialValue * Convert.ToDecimal(Math.Pow((1 + fee), months));

            return decimal.Round(recipe, 2);
        }
    }
}
