﻿
using System.ComponentModel.DataAnnotations;

namespace Sigma.Entity
{
    public class ECandidate
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public TimeOnly CallTimeInterval { get; set; }
        public string LinkedInURL { get; set; }
        public string GitHubURL { get; set; }
        public string FreeTextComment { get; set; }
    }

}
