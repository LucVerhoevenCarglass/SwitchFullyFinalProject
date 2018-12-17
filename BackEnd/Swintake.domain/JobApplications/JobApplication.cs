using Swintake.domain.Campaigns;
using Swintake.domain.Candidates;
using Swintake.infrastructure.builders;
using System;
using System.Collections.Generic;
using System.Text;
using Swintake.domain.JobApplications.SelectionSteps;

namespace Swintake.domain.JobApplications
{
   public class JobApplication: Entity
    {
        public Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }
        public Campaign Campaign { get; set; }
        public Guid CampaignId { get; set; }
        public ICollection<SelectionStep> SelectionSteps { get; set; }
        public StatusJobApplication Status { get; set; }

        private JobApplication(){}

        public JobApplication(JobApplicationBuilder jobApplicationBuilder)
        {
            CandidateId = jobApplicationBuilder.CandiDateId;
            CampaignId = jobApplicationBuilder.CampaignId;
            Status = jobApplicationBuilder.Status;
            SelectionSteps = new List<SelectionStep>();
        }

        public void SetNewStatus(StatusJobApplication newStatus)
        {
            Status = newStatus;
        }
    }

    public class JobApplicationBuilder : Builder<JobApplication>
    {
        public Guid Id { get; set; }
        public Guid CandiDateId { get; set; }
        public Guid CampaignId { get; set; }
        public StatusJobApplication Status { get; set; }

        public static JobApplicationBuilder NewJobApplication()
        {
            return new JobApplicationBuilder();
        }

        public JobApplicationBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public JobApplicationBuilder WithCandidateId(Guid candidateId)
        {
            CandiDateId = candidateId;
            return this;
        }

        public JobApplicationBuilder WithCampaignId(Guid campaignId)
        {
            CampaignId = campaignId;
            return this;
        }

       public JobApplicationBuilder WithStatus(StatusJobApplication status)
        {
            Status = status;
            return this;
        }
        public override JobApplication Build()
        {
            return new JobApplication(this);
        }
    }
}
