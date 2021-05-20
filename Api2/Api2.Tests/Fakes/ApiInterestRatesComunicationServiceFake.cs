using Api2.Application.Models;
using Api2.Application.Repositories;

namespace Api2.Tests.Fakes
{
    public class ApiInterestRatesComunicationServiceFake : IServiceApiInterestsRates
    {
        public double FindValueInterestRates(string urlBaseApi)
        {
            var interests = new MInterestsRates
            {
                Value = 0.01
            };

            return interests.Value;
        }
    }
}
