using Api2.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api2.Tests.Integrations
{
    public class InterestRatesCalculateControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public InterestRatesCalculateControllerIntegrationTests()
        {
            //arrange
            _server = new TestServer(
                new WebHostBuilder()
                    .ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.AddJsonFile("testsettings.json");
                    })
                    .UseStartup<Startup>()
                    .UseEnvironment("Development")
            );
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task When_Route_Get_Return_Calculated_Rates()
        {
            //act
            var response = await _client.GetAsync("/calculajuros?valorinicial=100&meses=5");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //assert
            Assert.Equal("105.10", responseString);
        }

    }
}
