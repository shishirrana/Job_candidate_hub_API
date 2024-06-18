using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Entity
{
    public class ECandidate
    {
        [Key]
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [StringLength(13)]
        public string PhoneNumber { get; set; }
        public TimeSpan? CallTimeInterval { get; set; }
        public string LinkedInURL { get; set; }
        public string GitHubURL { get; set; }
        [Required]
        public string FreeTextComment { get; set; }
    }
}
