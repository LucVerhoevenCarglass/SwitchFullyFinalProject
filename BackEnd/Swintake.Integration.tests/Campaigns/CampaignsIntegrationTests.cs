using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Swintake.api.Helpers.Users;
using Swintake.domain.Data;
using Swintake.domain.Users;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Swintake.api.Helpers.Campaigns;
using System;

namespace Swintake.Integration.tests.Campaigns
{
    public class CampaignsIntegrationTests
    {
        [Fact]
        public async Task GivenNewCampaignJson_WhenCreatingNewCampaign_ThenCampaignObjectIsSavedAndReturned()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .Build()));

            using (server)
            {
                var client = server.CreateClient();

                var context = server.Host.Services.GetService<SwintakeContext>();

                var newDTOCreated = new CreateCampaignDto()
                {
                    Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(5),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var content = JsonConvert.SerializeObject(newDTOCreated);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/campaign/", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();

                Assert.Equal("Created", response.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenNewCampaignJsonWithoutName_WhenCreatingNewCampaign_ThenReturnBadRequest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .Build()));

            using (server)
            {
                var client = server.CreateClient();

                var context = server.Host.Services.GetService<SwintakeContext>();

                var newDTOCreated = new CreateCampaignDto()
                {
                   // Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(5),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var content = JsonConvert.SerializeObject(newDTOCreated);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/campaign/", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();

                Assert.Equal("BadRequest", response.StatusCode.ToString());
            }
        }

    }
}
