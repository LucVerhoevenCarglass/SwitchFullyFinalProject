using Swintake.domain;
using Swintake.domain.Candidates;
using Swintake.infrastructure.Exceptions;
using System;
using System.Collections.Generic;

namespace Swintake.services.Candidates
{
    public class CandidateService : ICandidateService
    {

        private readonly IRepository<Candidate> _candidateRepository;

        public CandidateService(IRepository<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Candidate AddCandidate(Candidate candidate)
        {
            if (candidate == null)
            {
                throw new EntityNotValidException("candidate is null", candidate);
            }
            if (candidate.Id == null
                || candidate.Id == Guid.Empty
                || string.IsNullOrWhiteSpace(candidate.FirstName)
                || string.IsNullOrWhiteSpace(candidate.LastName)
                || string.IsNullOrWhiteSpace(candidate.Email)
                || string.IsNullOrWhiteSpace(candidate.PhoneNumber)
                || !IsEmailValid(candidate.Email)
                )
            {
                throw new EntityNotValidException("some fields of candidate are invalid", candidate);
            }

            _candidateRepository.Save(candidate);
            return candidate;
        }

        public IEnumerable<Candidate> GetAllCandidates()
        {
            throw new NotImplementedException();
        }

        public Candidate GetCandidateByID(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailValid(string email)
        {
            return email.Contains('@');
        }
    }
}
