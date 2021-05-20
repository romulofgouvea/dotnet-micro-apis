using Api2.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api2.Tests.Integrations
{
    public class ShowCodeControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ShowCodeControllerIntegrationTests()
        {
            //arrange
            _server = new TestServer(
                new WebHostBuilder()
                    .UseStartup<Startup>()
                    .UseEnvironment("Development")
            );
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task When_Root_Path_Return_Api2_Started()
        {
            //act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //assert
            Assert.Equal("API2 started! Development", responseString);
        }

        [Fact]
        public async Task When_Route_Show_The_Code_Redirect_To_Github()
        {
            //act
            var response = await _client.GetAsync("/showmethecode");

            //assert
            Assert.Equal(302, (int)response.StatusCode);
            Assert.Equal(
                new Uri("https://github.com/romulofgouvea/dotnet-micro-apis"),
                response.Headers.Location
            );
        }
    }
}
