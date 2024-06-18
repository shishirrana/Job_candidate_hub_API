using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Services.Candidate.Model
{
    public class CandidateVM
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public TimeSpan? CallTimeInterval { get; set; }
        public string LinkedInURL { get; set; }
        public string GitHubURL { get; set; }
        public string FreeTextComment { get; set; }
    }
}
