using Api2.Application.Models;
using Xunit;

namespace Api2.Tests.Units.Models
{
    public class MCompoundInterestTests
    {
        [Fact]
        public void When_Create_With_Mount_Zero_Shoud_Be_Invalid()
        {
            //act
            var c = new MCompoundInterest
            {
                InicialValue = 0,
                Mounths = 0,
                Tax = 0
            };

            //assert
            Assert.False(c.Valid());
        }

        [Fact]
        public void When_Create_With_Tax_Lower_Zero_Shoud_Be_Invalid()
        {
            //act
            var c = new MCompoundInterest
            {
                InicialValue = 0,
                Mounths = 1,
                Tax = -1
            };

            //assert
            Assert.False(c.Valid());
        }
    }
}
