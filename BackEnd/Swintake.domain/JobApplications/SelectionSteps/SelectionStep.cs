using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swintake.domain.JobApplications.SelectionSteps
{
    public abstract class SelectionStep
    {
        public Guid Id { get; set; }
        [MaxLength(90)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }

    }
}
