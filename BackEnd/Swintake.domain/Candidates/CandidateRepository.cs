using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.Candidates
{
    public class CandidateRepository : IRepository<Candidate>
    {
        SwintakeContext _context;

        public CandidateRepository(SwintakeContext context)
        {
            _context = context;
        }

        public Candidate Get(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IList<Candidate> GetAll()
        {
            throw new NotImplementedException();
        }

        public Candidate Save(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return candidate;
        }

        public Candidate Update(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
