using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Candidates
{
    public class CandidateDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string GitHubUsername { get; set; }
        public string LinkedIn { get; set; }
        public string Comment { get; set; }
    }
}
