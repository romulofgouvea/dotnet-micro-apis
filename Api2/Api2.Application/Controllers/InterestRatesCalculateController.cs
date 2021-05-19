using Api2.Application.Models;
using Api2.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            [FromQuery(Name = "meses")] int mounths,
            [FromServices] IServiceApiInterestsRates apiInterestService,
            [FromServices] IServiceCalculateInterestRates calculateInterestRatesService,
            [FromServices] IConfiguration configuration)
        {
            string baseUrlApi = configuration.GetValue<string>("Integrations:ApiInterestsRates");
            var tax = apiInterestService.FindValueInterestRates(baseUrlApi);

            var compoundInterest = new MCompoundInterest
            {
                InicialValue = initialValue,
                Mounths = mounths,
                Tax = tax
            };

            var recipe = calculateInterestRatesService
                .CalculateCompoundInterest(compoundInterest);

            return decimal.Round(recipe, 2);
        }
    }
}
