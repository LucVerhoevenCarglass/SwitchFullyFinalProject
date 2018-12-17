using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.JobApplications
{
    public class JobApplicationDto
    {
        public string Id { get; set; }
        public string CandidateId { get; set; }
        public string CampaignId { get; set; }
        public string Status { get; set; }

        public JobApplicationDto(string id, string candidateId, string campaignId, string status)
        {
            Id = id;
            CandidateId = candidateId;
            CampaignId = campaignId;
            Status = status;
        }
    }
}
