

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sigma.Services.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sigma.Services.Candidate.Model
{
    public class CandidateVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [StringLength(13, ErrorMessage = "Phone number cannot exceed 13 characters.")]
        public string PhoneNumber { get; set; }
        public TimeOnly CallTimeInterval { get; set; }

        public string LinkedInURL { get; set; }

        public string GitHubURL { get; set; }

        [Required(ErrorMessage = "Free text comment is required.")]
        public string FreeTextComment { get; set; }
    }
}
