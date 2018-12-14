using Microsoft.EntityFrameworkCore;
using Swintake.domain.Candidates;
using Swintake.domain.Data;
using System;
using System.Linq;
using Xunit;

namespace Swintake.domain.tests.Candidates
{
    public class CandidatesRepositoryTests
    {
        [Fact]
        public void GivenANewCandidate_WhenSaveNewCandidate_ThenNewCandidateIsSaved()
        {
            //given 
            var options = new DbContextOptionsBuilder<SwintakeContext>()
            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
            .Options;

            using (var context = new SwintakeContext(options))
            {
                var janneke = new CandidateBuilder()
                        .WithId(Guid.NewGuid())
                        .WithFirstName("Janneke")
                        .WithLastName("Janssens")
                        .WithEmail("janneke.janssens@gmail.com")
                        .WithPhoneNumber("0470000000")
                        .WithGitHubUsername("janneke")
                        .WithLinkedIn("janneke")
                        .Build();

                IRepository<Candidate> candidateRepository = new CandidateRepository(context);

                //when
                candidateRepository.Save(janneke);

                //then
                var foundCandidate = context.Candidates.SingleOrDefault(cand => cand.Id == janneke.Id);
                Assert.Equal(janneke.FirstName, foundCandidate.FirstName);
            }
        }

    }
}
