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
using Swintake.domain.Users;
using Swintake.api.Helpers.Users;

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

                var user = new UserBuilder()
                        .WithEmail("user@switchfully.com")
                        .WithFirstName("User")
                        .WithUserSecurity(new UserSecurity("WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=", "F1e3n6zNR75LhUd5K73T/g=="))
                        .Build();

                context.Users.Add(user);
                context.SaveChanges();

                var userDTO = new UserDTO { Email = "user@switchfully.com", Password = "ILoveNiels" };

                var contentUser = JsonConvert.SerializeObject(userDTO);
                var stringContentUser = new StringContent(contentUser, Encoding.UTF8, "application/json");

                var responseToken = await client.PostAsync("api/users/authenticate", stringContentUser);
                var responseStringToken = await responseToken.Content.ReadAsStringAsync();
                var responseBearer1 = responseStringToken.Substring(1);
                var responseBearer2 = responseBearer1.Substring(0, responseBearer1.Length - 1);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseBearer2);

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

                var user = new UserBuilder()
                        .WithEmail("user@switchfully.com")
                        .WithFirstName("User")
                        .WithUserSecurity(new UserSecurity("WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=", "F1e3n6zNR75LhUd5K73T/g=="))
                        .Build();

                context.Users.Add(user);
                context.SaveChanges();

                var userDTO = new UserDTO { Email = "user@switchfully.com", Password = "ILoveNiels" };

                var contentUser = JsonConvert.SerializeObject(userDTO);
                var stringContentUser = new StringContent(contentUser, Encoding.UTF8, "application/json");

                var responseToken = await client.PostAsync("api/users/authenticate", stringContentUser);
                var responseStringToken = await responseToken.Content.ReadAsStringAsync();
                var responseBearer1 = responseStringToken.Substring(1);
                var responseBearer2 = responseBearer1.Substring(0, responseBearer1.Length - 1);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseBearer2);

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
