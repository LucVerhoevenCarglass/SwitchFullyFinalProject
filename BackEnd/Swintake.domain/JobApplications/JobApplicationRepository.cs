﻿using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Swintake.domain.JobApplications
{
    public class JobApplicationRepository : IRepository<JobApplication>
    {
        private readonly SwintakeContext _context;

        public JobApplicationRepository(SwintakeContext context)
        {
            _context = context;
        }

        public JobApplication Get(Guid id)
        {
            var jobapplication = _context.JobApplications.SingleOrDefault(jobapp => jobapp.Id == id);
            return jobapplication;
        }

        public IList<JobApplication> GetAll()
        {
            return _context.JobApplications
                .Include(jp => jp.Campaign)
                .Include(jp => jp.Candidate)
                .Include(jp => jp.Status)
                .ToList();
        }

        public JobApplication Save(JobApplication jobapplication)
        {
            _context.JobApplications.Add(jobapplication);
            _context.SelectionSteps.Add(jobapplication.CurrentSelectionStep);
            _context.SaveChanges();
            return jobapplication;
        }

        public JobApplication Update(JobApplication jobAppToUpdate)
        {
            _context.JobApplications.Update(jobAppToUpdate);
            _context.SaveChanges();
            return jobAppToUpdate;
        }

    }
}
