using Microsoft.EntityFrameworkCore;
using Swintake.domain.Data;
using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Swintake.domain.tests.JobApplications
{
   public class JobApplicationRepositoryTest
    {
        private DbContextOptions<SwintakeContext> _options;
        private JobApplicationRepository _jobApplicationRepository;

        public JobApplicationRepositoryTest()
        {
            //given 
            _options = new DbContextOptionsBuilder<SwintakeContext>()
                .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                .Options;
            
        }

        [Fact]
        public void GivenNewJobapplication_WhenSavingNewJobapplication_ThenJobapplicationIsSaved()
        {
            using (var context = new SwintakeContext(_options))
            {
                //Given
                var newJobApplication = new JobApplicationBuilder()
                    .WithId(Guid.NewGuid())
                    .WithCandidateId(Guid.NewGuid())
                    .WithCampaignId(Guid.NewGuid())
                    .WithStatus(StatusJobApplication.Active)
                    .Build();

                _jobApplicationRepository = new JobApplicationRepository(context);

                //When
                _jobApplicationRepository.Save(newJobApplication);

                //Then
                Assert.Contains(newJobApplication, context.JobApplications);
            }
        }
    }
}
