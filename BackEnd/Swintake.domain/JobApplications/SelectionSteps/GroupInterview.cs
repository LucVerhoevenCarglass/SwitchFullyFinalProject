using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class GroupInterview: SelectionStep
    {
        public GroupInterview()
        {
            Id= Guid.NewGuid();
            Description = "Register Group interview";
        }
    }
}
