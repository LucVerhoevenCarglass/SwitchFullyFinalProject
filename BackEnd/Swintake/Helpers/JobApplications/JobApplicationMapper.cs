using Swintake.domain.JobApplications;
using Swintake.infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swintake.domain.JobApplications.SelectionSteps;

namespace Swintake.api.Helpers.JobApplications
{
    public class JobApplicationMapper : Mapper<JobApplicationDto, JobApplication>
    {
        private SelectionStepMapper _selectionStepMapper;
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
            _selectionStepMapper = new SelectionStepMapper();
            var jobappDto = new JobApplicationDto()
            {
                Id = domainObject.Id.ToString(),
                CandidateId = domainObject.CandidateId.ToString(),
                CampaignId = domainObject.CampaignId.ToString(),
                Status = domainObject.Status.ToString(),

            };
            if (domainObject.CurrentSelectionStep != null)
            {
                jobappDto.SelectionSteps = _selectionStepMapper.ToDtoList(domainObject.SelectionSteps);
                jobappDto.CurrentSelectionStep = _selectionStepMapper.ToDto(domainObject.CurrentSelectionStep);
            }
            return jobappDto;
        }

    }

    public class SelectionStepMapper 
    {
        public List<SelectionStepDto> ToDtoList(List<SelectionStep> selectionstep)
        {
            return selectionstep.Select(sel => { return ToDto(sel); }).ToList();
        }

        public SelectionStepDto ToDto(SelectionStep domainObject)
        {
            return new SelectionStepDto()
            {
                JobApplicationId = domainObject.JobApplicationId,
                Comment = domainObject.Comment,
                Description = domainObject.Description
            };
        }


    }
}
