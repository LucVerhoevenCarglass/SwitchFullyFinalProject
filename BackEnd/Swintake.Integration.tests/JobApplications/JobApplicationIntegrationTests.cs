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
using Swintake.domain.Users;
using Swintake.api.Helpers.Users;
using Swintake.api.Helpers.Candidates;
using Swintake.api.Helpers.Campaigns;
using Swintake.api.Helpers.JobApplications;

namespace Swintake.Integration.tests
{
  public class JobApplicationIntegrationTests
    {
        private readonly TestServer _server;

        public JobApplicationIntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
                    .Build()));
        }

        private async Task<HttpClient> InitClient(TestServer server)
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

            var userDto = new UserDTO { Email = "user@switchfully.com", Password = "ILoveNiels" };

            var contentUser = JsonConvert.SerializeObject(userDto);
            var stringContentUser = new StringContent(contentUser, Encoding.UTF8, "application/json");

            var responseToken = await client.PostAsync("api/users/authenticate", stringContentUser);
            var responseStringToken = await responseToken.Content.ReadAsStringAsync();
            var responseBearer1 = responseStringToken.Substring(1);
            var responseBearer2 = responseBearer1.Substring(0, responseBearer1.Length - 1);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseBearer2);
            return client;
        }

        [Fact]
        public async Task GivenNewJobApplicationWithExistingCampaignIdAndExistingCandidateId_WhenCreateNewJobApplication_ThenReturnSuccessAndJobApplicationDtoWithId()
        {
            using (_server)
            {
                var client = await InitClient(_server);

                var newDTOCreatedCandidate = new CandidateDto()
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "totallynotspiderman@gmail.com",
                    PhoneNumber = "0470000000",
                    GitHubUsername = "youarespiderman",
                    LinkedIn = "peterparker"
                };

                var contentCandidate = JsonConvert.SerializeObject(newDTOCreatedCandidate);
                var stringContentCandidate = new StringContent(contentCandidate, Encoding.UTF8, "application/json");

                var responseCandidate = await client.PostAsync("api/Candidates", stringContentCandidate);
                var responseStringCandidate = await responseCandidate.Content.ReadAsStringAsync();
                var createdCandidate = JsonConvert.DeserializeObject<CandidateDto>(responseStringCandidate);

                var newDTOCreatedCampaign = new CreateCampaignDto()
                {
                    Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(6),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var contentCampaign = JsonConvert.SerializeObject(newDTOCreatedCampaign);
                var stringContentCampaign = new StringContent(contentCampaign, Encoding.UTF8, "application/json");
                var responseCampaign = await client.PostAsync("api/campaigns", stringContentCampaign);
                var responseStringCampaign = await responseCampaign.Content.ReadAsStringAsync();
                var createdCampaign = JsonConvert.DeserializeObject<CampaignDto>(responseStringCampaign);

                var newJobApplicationCreatedDto = new CreateJobApplicationDto(
                     createdCandidate.Id,
                     createdCampaign.Id
               );

                var contentJobApplication = JsonConvert.SerializeObject(newJobApplicationCreatedDto);
                var stringContentJobApplication = new StringContent(contentJobApplication, Encoding.UTF8, "application/json");
                var responseJobApplication = await client.PostAsync("api/jobapplications", stringContentJobApplication);

                Assert.Equal("Created", responseJobApplication.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenNewJobApplicationWithExistingCampaignIdAndNonExistingCandidateId_WhenCreateNewJobApplication_ThenReturnNotFound()
        {
            using (_server)
            {
                var client = await InitClient(_server);

                var newDTOCreatedCandidate = new CandidateDto()
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "totallynotspiderman@gmail.com",
                    PhoneNumber = "0470000000",
                    GitHubUsername = "youarespiderman",
                    LinkedIn = "peterparker"
                };

                var contentCandidate = JsonConvert.SerializeObject(newDTOCreatedCandidate);
                var stringContentCandidate = new StringContent(contentCandidate, Encoding.UTF8, "application/json");

                var responseCandidate = await client.PostAsync("api/Candidates", stringContentCandidate);
                var responseStringCandidate = await responseCandidate.Content.ReadAsStringAsync();
                var createdCandidate = JsonConvert.DeserializeObject<CandidateDto>(responseStringCandidate);

                var newDTOCreatedCampaign = new CreateCampaignDto()
                {
                    Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(6),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var contentCampaign = JsonConvert.SerializeObject(newDTOCreatedCampaign);
                var stringContentCampaign = new StringContent(contentCampaign, Encoding.UTF8, "application/json");
                var responseCampaign = await client.PostAsync("api/campaigns", stringContentCampaign);
                var responseStringCampaign = await responseCampaign.Content.ReadAsStringAsync();
                var createdCampaign = JsonConvert.DeserializeObject<CampaignDto>(responseStringCampaign);

                var newJobApplicationCreatedDto = new CreateJobApplicationDto(
                
                     createdCampaign.Id,
                    Guid.NewGuid().ToString()
                );

                var contentJobApplication = JsonConvert.SerializeObject(newJobApplicationCreatedDto);
                var stringContentJobApplication = new StringContent(contentJobApplication, Encoding.UTF8, "application/json");
                var responseJobApplication = await client.PostAsync("api/jobapplications", stringContentJobApplication);

                Assert.Equal("NotFound", responseJobApplication.StatusCode.ToString());
            }
        }


        [Fact]
        public async Task GivenNewJobApplicationWithNotExistingCampaignIdAndExistingCandidateId_WhenCreateNewJobApplication_ThenReturnNotFound()
        {
            using (_server)
            {
                var client = await InitClient(_server);

                var newDTOCreatedCandidate = new CandidateDto()
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "totallynotspiderman@gmail.com",
                    PhoneNumber = "0470000000",
                    GitHubUsername = "youarespiderman",
                    LinkedIn = "peterparker"
                };

                var contentCandidate = JsonConvert.SerializeObject(newDTOCreatedCandidate);
                var stringContentCandidate = new StringContent(contentCandidate, Encoding.UTF8, "application/json");

                var responseCandidate = await client.PostAsync("api/Candidates", stringContentCandidate);
                var responseStringCandidate = await responseCandidate.Content.ReadAsStringAsync();
                var createdCandidate = JsonConvert.DeserializeObject<CandidateDto>(responseStringCandidate);

                var newDTOCreatedCampaign = new CreateCampaignDto()
                {
                    Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(6),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var contentCampaign = JsonConvert.SerializeObject(newDTOCreatedCampaign);
                var stringContentCampaign = new StringContent(contentCampaign, Encoding.UTF8, "application/json");
                var responseCampaign = await client.PostAsync("api/campaigns", stringContentCampaign);
                var responseStringCampaign = await responseCampaign.Content.ReadAsStringAsync();
                var createdCampaign = JsonConvert.DeserializeObject<CampaignDto>(responseStringCampaign);

                var newJobApplicationCreatedDto = new CreateJobApplicationDto(
                     createdCampaign.Id,
                     Guid.NewGuid().ToString()
                );

                var contentJobApplication = JsonConvert.SerializeObject(newJobApplicationCreatedDto);
                var stringContentJobApplication = new StringContent(contentJobApplication, Encoding.UTF8, "application/json");
                var responseJobApplication = await client.PostAsync("api/jobapplications", stringContentJobApplication);

                Assert.Equal("NotFound", responseJobApplication.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenGetJobApplication_WhenPassingExistingId_ThenReturnJobApplication()
        {
            using (_server)
            {
                var client = await InitClient(_server);

                var newDTOCreatedCandidate = new CandidateDto()
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "totallynotspiderman@gmail.com",
                    PhoneNumber = "0470000000",
                    GitHubUsername = "youarespiderman",
                    LinkedIn = "peterparker"
                };

                var contentCandidate = JsonConvert.SerializeObject(newDTOCreatedCandidate);
                var stringContentCandidate = new StringContent(contentCandidate, Encoding.UTF8, "application/json");
                var responseCandidate = await client.PostAsync("api/Candidates", stringContentCandidate);
                var responseStringCandidate = await responseCandidate.Content.ReadAsStringAsync();
                var createdCandidate = JsonConvert.DeserializeObject<CandidateDto>(responseStringCandidate);

                var newDTOCreatedCampaign = new CreateCampaignDto()
                {
                    Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(6),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var contentCampaign = JsonConvert.SerializeObject(newDTOCreatedCampaign);
                var stringContentCampaign = new StringContent(contentCampaign, Encoding.UTF8, "application/json");
                var responseCampaign = await client.PostAsync("api/campaigns", stringContentCampaign);
                var responseStringCampaign = await responseCampaign.Content.ReadAsStringAsync();
                var createdCampaign = JsonConvert.DeserializeObject<CampaignDto>(responseStringCampaign);

                var newJobApplicationCreatedDto = new CreateJobApplicationDto(
                    createdCandidate.Id,
                    createdCampaign.Id
                );

                var content = JsonConvert.SerializeObject(newJobApplicationCreatedDto);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/JobApplications", stringContent);
                response.EnsureSuccessStatusCode();
                var creatingResponseString = await response.Content.ReadAsStringAsync();
                var createdJobApplication = JsonConvert.DeserializeObject<JobApplicationDto>(creatingResponseString);

                var getResponse = await client.GetAsync("/api/JobApplications/" + createdJobApplication.Id);
                var responseString = await getResponse.Content.ReadAsStringAsync();
                var foundJobApplication = JsonConvert.DeserializeObject<JobApplicationDto>(responseString);

                Assert.Equal(newJobApplicationCreatedDto.CampaignId, foundJobApplication.CampaignId);
                Assert.Equal(newJobApplicationCreatedDto.CandidateId, foundJobApplication.CandidateId);
            }
        }

        [Fact]
        public async Task GivenGetJobApplication_WhenPassingNonExistingId_ThenReturnNull()
        {
            using (_server)
            {
                var client = await InitClient(_server);
                var getResponse = await client.GetAsync("/api/JobApplications/" + Guid.NewGuid().ToString());
                var responseString = await getResponse.Content.ReadAsStringAsync();
                Assert.Equal("NotFound", getResponse.StatusCode.ToString());
            }
        }

    }
}
