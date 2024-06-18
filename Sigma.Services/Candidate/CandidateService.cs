using Sigma.Entity;
using Sigma.Services.Candidate.Model;
using Sigma.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigma.Services.Candidate
{
    public class CandidateService : ICandidateService
    {
        private readonly IServiceRepository<ECandidate> candidateCRUD;

        public CandidateService(IServiceRepository<ECandidate> candidateCRUD)
        {
            this.candidateCRUD = candidateCRUD;
        }

        public IResult<string> AddOrUpdate(CandidateVM model)
        {
            try
            {
                var existingCandidate = candidateCRUD.List().FirstOrDefault(c => c.Email == model.Email);

                if (existingCandidate != null)
                {
                    existingCandidate.FirstName = model.FirstName;
                    existingCandidate.LastName = model.LastName;
                    existingCandidate.PhoneNumber = model.PhoneNumber;
                    existingCandidate.CallTimeInterval = model.CallTimeInterval;
                    existingCandidate.LinkedInURL = model.LinkedInURL;
                    existingCandidate.GitHubURL = model.GitHubURL;
                    existingCandidate.FreeTextComment = model.FreeTextComment;

                    candidateCRUD.Update(existingCandidate);

                    return new IResult<string>
                    {
                        Data = existingCandidate.Email,
                        Status = ResultStatus.Success,
                        Message = "Candidate updated successfully."
                    };
                }
                else
                {
                    var candidate = new ECandidate
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        CallTimeInterval = model.CallTimeInterval,
                        LinkedInURL = model.LinkedInURL,
                        GitHubURL = model.GitHubURL,
                        FreeTextComment = model.FreeTextComment
                    };

                    candidateCRUD.Add(candidate);

                    return new IResult<string>
                    {
                        Data = candidate.Email,
                        Status = ResultStatus.Success,
                        Message = "Candidate added successfully."
                    };
                }
            }
            catch (Exception ex)
            {
                return new IResult<string>
                {
                    Message = ex.Message,
                    Status = ResultStatus.Failure
                };
            }
        }
        public IResult<int> Delete(string email)
        {
            try
            {
                var rowsAffected = candidateCRUD.Delete(email);

                return rowsAffected > 0
                    ? new IResult<int>
                    {
                        Data = rowsAffected,
                        Status = ResultStatus.Success,
                        Message = "Candidate deleted successfully."
                    }
                    : new IResult<int>
                    {
                        Status = ResultStatus.Failure,
                        Message = "Candidate not found."
                    };
            }
            catch (Exception ex)
            {
                return new IResult<int>
                {
                    Message = ex.Message,
                    Status = ResultStatus.Failure
                };
            }
        }

        public IResult<CandidateVM> Get(string email)
        {
            try
            {
                var candidate = candidateCRUD.Find(email);
                if (candidate == null)
                {
                    return new IResult<CandidateVM>
                    {
                        Status = ResultStatus.Failure,
                        Message = "Candidate not found."
                    };
                }

                var candidateVM = new CandidateVM
                {
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    PhoneNumber = candidate.PhoneNumber,
                    CallTimeInterval = candidate.CallTimeInterval,
                    LinkedInURL = candidate.LinkedInURL,
                    GitHubURL = candidate.GitHubURL,
                    FreeTextComment = candidate.FreeTextComment
                };

                return new IResult<CandidateVM>
                {
                    Data = candidateVM,
                    Status = ResultStatus.Success,
                    Message = "Candidate retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                return new IResult<CandidateVM>
                {
                    Message = ex.Message,
                    Status = ResultStatus.Failure
                };
            }
        }

        public IResult<List<CandidateVM>> List()
        {
            try
            {
                var candidates = candidateCRUD.List().Select(candidate => new CandidateVM
                {
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    PhoneNumber = candidate.PhoneNumber,
                    CallTimeInterval = candidate.CallTimeInterval,
                    LinkedInURL = candidate.LinkedInURL,
                    GitHubURL = candidate.GitHubURL,
                    FreeTextComment = candidate.FreeTextComment
                }).ToList();

                return new IResult<List<CandidateVM>>
                {
                    Data = candidates,
                    Status = ResultStatus.Success,
                    Message = "Candidates retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                return new IResult<List<CandidateVM>>
                {
                    Message = ex.Message,
                    Status = ResultStatus.Failure
                };
            }
        }

    }
}
