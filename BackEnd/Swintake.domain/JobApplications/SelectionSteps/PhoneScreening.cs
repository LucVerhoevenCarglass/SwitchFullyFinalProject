using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class PhoneScreening: SelectionStep
    {
        public PhoneScreening()
        {
            Id = Guid.NewGuid();
            Description = "Register Phone Screening";
        }
    }
}
