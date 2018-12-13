using Swintake.infrastructure.builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.Candidates
{
    public class Candidate : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string GitHubUsername { get; private set; }
        public string LinkedIn { get; private set; }

        private Candidate() { }

        public Candidate(CandidateBuilder candidateBuilder) : base(candidateBuilder.Id)
        {
            FirstName = candidateBuilder.FirstName;
            LastName = candidateBuilder.LastName;
            Email = candidateBuilder.Email;
            PhoneNumber = candidateBuilder.PhoneNumber;
            GitHubUsername = candidateBuilder.GitHubUsername;
            LinkedIn = candidateBuilder.LinkedIn;
        }
    }

    public class CandidateBuilder : Builder<Candidate>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string GitHubUsername { get; set; }
        public string LinkedIn { get; set; }

        public static CandidateBuilder NewCandidate()
        {
            return new CandidateBuilder();
        }

        public CandidateBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public CandidateBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public CandidateBuilder WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public CandidateBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CandidateBuilder WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public CandidateBuilder WithGitHubUsername(string gitUserName)
        {
            GitHubUsername = gitUserName;
            return this;
        }

        public CandidateBuilder WithLinkedIn(string linkedIn)
        {
            LinkedIn = linkedIn;
            return this;
        }

        public override Candidate Build()
        {
           return new Candidate(this);
        }
    }
}
