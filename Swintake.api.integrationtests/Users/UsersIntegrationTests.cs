using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swintake.api.Helpers.Users;
using Swintake.domain.Data;
using Swintake.domain.Users;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Swintake.api.integrationtests.Users
{
    public class UsersIntegrationTests
    {
        private static DbContextOptions<SwintakeContext> CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<SwintakeContext>()
                .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                .Options;
        }


        [Fact]
        public async Task GivenExistingUser_WhenAuthenticate_ThenReturnOkWithJwtSecurityTokenRawData()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());

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

                var content = JsonConvert.SerializeObject(userDTO);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/users/authenticate", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();
                var test = JsonConvert.DeserializeObject(responseString);

                Assert.True(response.IsSuccessStatusCode);
            }
        }
    }
}
