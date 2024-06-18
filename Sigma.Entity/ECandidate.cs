
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sigma.Entity
{
    public class ECandidate
    {
        [Key]
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
