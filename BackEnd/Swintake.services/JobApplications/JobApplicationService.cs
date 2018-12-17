using System;
using System.Collections.Generic;
using System.Text;
using Swintake.domain;
using Swintake.domain.JobApplications;
using Swintake.infrastructure.Exceptions;
using Swintake.services.Campaigns;
using Swintake.services.Candidates;

namespace Swintake.services.JobApplications
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IRepository<JobApplication> _repository;
        private readonly ICandidateService _candidateService;
        private readonly ICampaignService _campaignService;

        public JobApplicationService(IRepository<JobApplication> repository, ICandidateService candidateService, ICampaignService campaignService)
        {
            _repository = repository;
            _candidateService = candidateService;
            _campaignService = campaignService;
        }

        public JobApplication AddJobApplication(JobApplication jobApplication)
        {
            var foundcandidate = _candidateService.GetCandidateById(jobApplication.CandidateId.ToString());
            var foundCampaign = _campaignService.GetCampaignByID(jobApplication.CampaignId.ToString());
            
            return _repository.Save(jobApplication);
        }
    }
}
