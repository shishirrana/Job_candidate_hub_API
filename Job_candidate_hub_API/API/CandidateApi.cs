using Microsoft.AspNetCore.Mvc;
using Sigma.Services.Candidate;
using Sigma.Services.Candidate.Model;
using Sigma.Services.Common;


namespace Job_candidate_hub_API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateApi : ControllerBase
    {
        private readonly ICandidateService candidateService;

        public CandidateApi(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        [HttpPost("AddOrUpdate")]
        public IResult<string> AddOrUpdateCandidate([FromBody] CandidateVM model)
        {
            return candidateService.AddOrUpdate(model);
        }

        [HttpDelete("Delete/{email}")]
        public IResult<int> DeleteCandidate(string email)
        {
            return candidateService.Delete(email);
        }

        [HttpGet("Get/{email}")]
        public IResult<CandidateVM> GetCandidate(string email)
        {
            return candidateService.Get(email);            
        }

        [HttpGet("List")]
        public IResult<List<CandidateVM>> ListCandidates()
        {
            return candidateService.List();
        }
    }
}
