using Api1.Domain.Entities;
using Xunit;

namespace Api1.Tests
{
    public class InterestRatesTests
    {
        [Fact]
        public void When_Create_Interest_Rates_One_Percent_Shoud_Be_Equal()
        {
            //act
            var f = new InterestRates(1.0 / 100);

            //assert
            Assert.Equal(0.01, f.Value);
        }
    }
}
