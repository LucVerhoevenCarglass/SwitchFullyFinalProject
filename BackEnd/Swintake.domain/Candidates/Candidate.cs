using Swintake.infrastructure.builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swintake.domain.Candidates
{
    public class Candidate : Entity
    {
        [MaxLength(60)]
        public string FirstName { get; private set; }
        [MaxLength(60)]
        public string LastName { get; private set; }
        [MaxLength(100)]
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        [MaxLength(100)]
        public string GitHubUsername { get; private set; }
        [MaxLength(200)]
        public string LinkedIn { get; private set; }
        [MaxLength(500)]
        public string Comment { get; private set; }

        private Candidate() { }

        public Candidate(CandidateBuilder candidateBuilder) : base(candidateBuilder.Id)
        {
            FirstName = candidateBuilder.FirstName;
            LastName = candidateBuilder.LastName;
            Email = candidateBuilder.Email;
            PhoneNumber = candidateBuilder.PhoneNumber;
            GitHubUsername = candidateBuilder.GitHubUsername;
            LinkedIn = candidateBuilder.LinkedIn;
            Comment = candidateBuilder.Comment;
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
        public string Comment { get; set; }

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

        public CandidateBuilder WithComment(string comment)
        {
            Comment = comment;
            return this;
        }

        public override Candidate Build()
        {
           return new Candidate(this);
        }
    }
}
