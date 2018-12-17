using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class AuditSelectionProcess : SelectionStep
    {
        public AuditSelectionProcess()
        {
            Id= Guid.NewGuid();
            Description = "Audit Selection process";
        }
    }
}
