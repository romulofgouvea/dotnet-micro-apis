using Api2.Application.Models;
using Xunit;

namespace Api2.Tests.Units.Models
{
    public class MInteretsRatesTests
    {
        [Fact]
        public void When_Create_With_Value_Greather_zero_Shoud_Be_Valid()
        {
            //act
            var c = new MInterestsRates
            {
                Value = 0
            };

            //assert
            Assert.True(c.Valid());
        }

        [Fact]
        public void When_Create_With_Value_Negative_Shoud_Be_Invalid()
        {
            //act
            var c = new MInterestsRates
            {
                Value = -1
            };

            //assert
            Assert.False(c.Valid());
        }
    }
}
