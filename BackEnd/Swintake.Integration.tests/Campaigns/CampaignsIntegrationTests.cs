using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Swintake.domain.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Swintake.api.Helpers.Campaigns;

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
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
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

                var response = await client.PostAsync("api/campaigns", stringContent);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var createdCampaign = JsonConvert.DeserializeObject<CampaignDto>(responseString);

                Assert.Equal("Created", response.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenNewCampaignJsonWithoutName_WhenCreatingNewCampaign_ThenReturnBadRequest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
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

                var response = await client.PostAsync("api/campaigns", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();

                Assert.Equal("BadRequest", response.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenHappyPath_WhenGetAllCampaigns_ThenCampaignsAreReturned()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
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

                var response = await client.GetAsync("api/campaigns");
                response.EnsureSuccessStatusCode();

                Assert.Equal("OK", response.StatusCode.ToString());
            }
        }
    }
}
