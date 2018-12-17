using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class FinalDecision: SelectionStep
    {
        public FinalDecision()
        {
            Id= Guid.NewGuid();
            Description = "Register Final decision";
        }
    }
}
