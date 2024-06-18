using Sigma.Entity;
using Sigma.Services.Candidate.Model;
using Sigma.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
