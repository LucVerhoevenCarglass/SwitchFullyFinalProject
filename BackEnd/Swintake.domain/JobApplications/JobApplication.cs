﻿using Swintake.domain.Campaigns;
using Swintake.domain.Candidates;
using Swintake.infrastructure.builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications
{
   public class JobApplication: Entity
    {
        public Candidate Candidate { get; set; }
        public Guid CandiDateId { get; set; }
        public Campaign Campaign { get; set; }
        public Guid CampaignId { get; set; }
        public DateTime CreationTime { get; set; }
        public StatusJobApplication Status { get; set; }

        private JobApplication(){}

        public JobApplication(JobApplicationBuilder jobApplicationBuilder)
        {
            CandiDateId = jobApplicationBuilder.CandiDateId;
            CampaignId = jobApplicationBuilder.CampaignId;
            CreationTime = jobApplicationBuilder.CreationTime;
            Status = jobApplicationBuilder.Status;
        }

    }

    public class JobApplicationBuilder : Builder<JobApplication>
    {
        public Guid Id { get; set; }
        public Guid CandiDateId { get; set; }
        public Guid CampaignId { get; set; }
        public DateTime CreationTime { get; set; }
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

        public JobApplicationBuilder WithCreationTime(DateTime creationTime)
        {
            CreationTime = creationTime;
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
