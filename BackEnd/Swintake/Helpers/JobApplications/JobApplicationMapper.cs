using Swintake.domain.JobApplications;
using Swintake.infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.JobApplications
{
    public class JobApplicationMapper : Mapper<JobApplicationDto, JobApplication>
    {
        public override JobApplication ToDomain(JobApplicationDto dtoObject)
        {
            return new JobApplicationBuilder()
                .WithId(new Guid(dtoObject.Id))
                .WithCampaignId(new Guid(dtoObject.CampaignId))
                .WithCandidateId(new Guid(dtoObject.CandidateId))
                .WithStatus(StatusJobApplication.Active)
                .Build();
        }

        public virtual JobApplication ToNewDomain(CreateJobApplicationDto dtoObject)
        {
            return new JobApplicationBuilder()
                .WithId(Guid.NewGuid())
                .WithCampaignId(new Guid(dtoObject.CampaignId))
                .WithCandidateId(new Guid(dtoObject.CandidateId))
                .WithStatus(StatusJobApplication.Active)
                .Build();
        }

        public override JobApplicationDto ToDto(JobApplication domainObject)
        {
            return new JobApplicationDto
            {
                Id = domainObject.Id.ToString(),
                CampaignId = domainObject.CampaignId.ToString(),
                CandidateId = domainObject.CandidateId.ToString(),
                Status = domainObject.Status.ToString()
            };
        }

    }
}
