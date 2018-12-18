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
            if (DoesCandidateAndCampaignOfThisJobApplicationExist(jobApplication))
            {
                return _repository.Save(jobApplication);
            }
            return null;
        }

        private bool DoesCandidateAndCampaignOfThisJobApplicationExist(JobApplication jobApplication)
        {
            _candidateService.GetCandidateById(jobApplication.CandidateId.ToString());
            _campaignService.GetCampaignByID(jobApplication.CampaignId.ToString());
            return true;
        }

        public void RejectJob(JobApplication jobApplicationToReject)
        {
            jobApplicationToReject.SetNewStatus(StatusJobApplication.Rejected);
            _repository.Update(jobApplicationToReject);         
        }

        public IEnumerable<JobApplication> GetJobApplications()
        {
            return _repository.GetAll();
        }

        public JobApplication GoToNextSelectionStepInSelectionProcess(string id, string comment)
        {
            JobApplication jobApplicationToUpdate = GetJobApplicationById(id);
            jobApplicationToUpdate.GotoNextSelectionStep(comment);
            _repository.Update(jobApplicationToUpdate);
            return jobApplicationToUpdate;
        }

        public JobApplication GetJobApplicationById(string id)
        {
            JobApplication jobApplication = _repository.Get(Guid.Parse(id));
            if (jobApplication == null)
            {
                throw new EntityNotFoundException("get job application", "job application", new Guid(id));
            }
            return jobApplication;
        }
    }
}
