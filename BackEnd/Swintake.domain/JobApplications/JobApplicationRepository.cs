using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swintake.domain.JobApplications
{
    public class JobApplicationRepository : IRepository<JobApplication>
    {
        private readonly SwintakeContext _context;

        public JobApplicationRepository(SwintakeContext context)
        {
            _context = context;
        }

        public JobApplication Get(Guid entityId)
        {
            return _context.JobApplications.SingleOrDefault(jobapp => jobapp.Id == entityId);
        }

        public IList<JobApplication> GetAll()
        {
            throw new NotImplementedException();
        }

        public JobApplication Save(JobApplication jobapplication)
        {
            _context.Add(jobapplication);
            _context.SaveChanges();
            return jobapplication;
        }

        public JobApplication Update(JobApplication entity)
        {
            throw new NotImplementedException();
        }
    }
}
