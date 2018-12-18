using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.services.JobApplications
{
    public interface IJobApplicationService
    {
        JobApplication AddJobApplication(JobApplication jobApplication);
        JobApplication GetJobApplicationById(string id);
        JobApplication RejectJobApplication(string jobApplicationIdToReject);
        IEnumerable<JobApplication> GetJobApplications();
        JobApplication GoToNextSelectionStepInSelectionProcess(string id);
    }
}
