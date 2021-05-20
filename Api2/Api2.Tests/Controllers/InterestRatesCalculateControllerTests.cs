using Api2.Application.Controllers;
using Api2.Application.Services;
using Api2.Tests.Fakes;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Api2.Tests.Controllers
{
    public class InterestRatesCalculateControllerTests
    {
        [Fact]
        public void When_Calculate_Shoud_Be_Valid()
        {
            //arrange
            var apiServiceFake = new ApiInterestRatesComunicationServiceFake();

            var calculateInterest = new CalculateInterestRatesService();
            var controller = new InterestRatesCalculateController();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"testsettings.json", optional: false)
                .Build();

            //act
            var result = controller.Get(
                100,
                5,
                apiServiceFake,
                calculateInterest,
                configuration
            );

            //assert
            Assert.Equal(105.10m, result);
        }

        [Fact]
        public void When_Calculate_With_Mounth_Invalid_Shoud_Be_Invalid()
        {
            //arrange
            var apiServiceFake = new ApiInterestRatesComunicationServiceFake();

            var calculateInterest = new CalculateInterestRatesService();
            var controller = new InterestRatesCalculateController();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"testsettings.json", optional: false)
                .Build();

            //act
            var result = controller.Get(
                100,
                0,
                apiServiceFake,
                calculateInterest,
                configuration
            );

            //assert
            Assert.Equal(0, result);
        }
    }
}
