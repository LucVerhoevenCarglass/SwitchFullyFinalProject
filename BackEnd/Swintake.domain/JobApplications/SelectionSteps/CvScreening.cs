using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class CvScreening: SelectionStep
    {
        public CvScreening()
        {
            Id= Guid.NewGuid();
            Description = "Register CV Screening";
        }
    }
}
