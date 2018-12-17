using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class FirstInterview: SelectionStep
    {
        public FirstInterview()
        {
            Id= Guid.NewGuid();
            Description = "Register First interview";
        }
    }
}
