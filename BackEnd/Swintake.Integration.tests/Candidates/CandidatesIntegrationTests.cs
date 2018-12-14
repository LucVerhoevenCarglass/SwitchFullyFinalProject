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
using Swintake.api.Helpers.Candidates;

namespace Swintake.Integration.tests.Candidates
{
    public class CandidatesIntegrationTests
    {
        [Fact]
        public async Task GivenNewCandidateJson_WhenCreatingNewCandidate_ThenCandidateObjectIsSavedAndReturned()
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

                var newDTOCreated = new CandidateDto()
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "totallynotspiderman@gmail.com",
                    PhoneNumber = "0470000000",
                    GitHubUsername = "youarespiderman",
                    LinkedIn = "peterparker"
                };

                var content = JsonConvert.SerializeObject(newDTOCreated);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/Candidates", stringContent);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var createdCandidate = JsonConvert.DeserializeObject<CandidateDto>(responseString);

                Assert.Equal("Created", response.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenNewCandidateJsonWithoutName_WhenCreatingNewCandidate_ThenReturnBadRequest()
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

                var newDTOCreated = new CandidateDto()
                {
                    FirstName = "",
                    LastName = "Parker",
                    Email = "totallynotspiderman@gmail.com",
                    PhoneNumber = "0470000000",
                    GitHubUsername = "youarespiderman",
                    LinkedIn = "peterparker"
                };

                var content = JsonConvert.SerializeObject(newDTOCreated);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/Candidates", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();

                Assert.Equal("BadRequest", response.StatusCode.ToString());
            }
        }
    }
}
