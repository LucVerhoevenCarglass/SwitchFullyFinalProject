using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class AuditSelectionProcess : SelectionStep
    {
        public AuditSelectionProcess()
        {
            Description = "Audit Selection process";
        }

        public override SelectionStep GoToNextState()
        {
            return this;
        }
    }
}
