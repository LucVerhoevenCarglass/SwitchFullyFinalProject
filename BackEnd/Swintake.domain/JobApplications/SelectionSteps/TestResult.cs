using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public class TestResult: SelectionStep
    {
        public TestResult()
        {
            Id= Guid.NewGuid();
            Description = "Register TestResults";
        }
    }
}
