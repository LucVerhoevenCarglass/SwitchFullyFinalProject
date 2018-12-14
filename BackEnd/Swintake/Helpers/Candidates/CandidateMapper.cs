using Swintake.domain.Candidates;
using Swintake.infrastructure.Mappers;
using System;

namespace Swintake.api.Helpers.Candidates
{
    public class CandidateMapper : Mapper<CandidateDto, Candidate>
    {
        public override Candidate ToDomain(CandidateDto dtoObject)
        {
            var domainCandidate = CandidateBuilder.NewCandidate()
                                    .WithId(Guid.NewGuid())
                                    .WithFirstName(dtoObject.FirstName)
                                    .WithLastName(dtoObject.LastName)
                                    .WithEmail(dtoObject.Email)
                                    .WithPhoneNumber(dtoObject.PhoneNumber)
                                    .WithGitHubUsername(dtoObject.GitHubUsername)
                                    .WithLinkedIn(dtoObject.LinkedIn)
                                    .WithComment(dtoObject.Comment)
                                    .Build();

            return domainCandidate;
        }

        public override CandidateDto ToDto(Candidate domainObject)
        {
            var dtoCandidate = new CandidateDto
            {
                Id = domainObject.Id.ToString(),
                FirstName = domainObject.FirstName,
                LastName = domainObject.LastName,
                Email = domainObject.Email,
                PhoneNumber = domainObject.PhoneNumber,
                GitHubUsername = domainObject.GitHubUsername,
                LinkedIn = domainObject.LinkedIn,
                Comment = domainObject.Comment

            };

            return dtoCandidate;
        }
    }
}
