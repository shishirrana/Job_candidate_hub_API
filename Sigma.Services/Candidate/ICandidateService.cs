using Sigma.Services.Candidate.Model;
using Sigma.Services.Common;

namespace Sigma.Services.Candidate
{
    public interface ICandidateService
    {
        IResult<string> AddOrUpdate(CandidateVM model);
        IResult<int> Delete(string email);
        IResult<CandidateVM> Get(string email);
        IResult<List<CandidateVM>> List();
    }
}
