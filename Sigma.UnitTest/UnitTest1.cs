using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sigma.Entity;
using Sigma.Services.Candidate;
using Sigma.Services.Candidate.Model;
using Sigma.Services.Common;
using System.Collections.Generic;
using System.Linq;

namespace Sigma.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IServiceRepository<ECandidate>> mockRepository;
        private CandidateService candidateService;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IServiceRepository<ECandidate>>();
            candidateService = new CandidateService(mockRepository.Object);
        }

        [TestMethod]
        public void AddOrUpdate_AddsNewCandidate_ReturnsSuccess()
        {
            var candidateVM = new CandidateVM
            {
                Email = "newuser@example.com",
                FirstName = "New",
                LastName = "User",
                PhoneNumber = "1234567890",
                CallTimeInterval = new TimeOnly(1, 4),
                LinkedInURL = "http://linkedin.com/newuser",
                GitHubURL = "http://github.com/newuser",
                FreeTextComment = "New candidate"
            };
            mockRepository.Setup(repo => repo.List()).Returns(new List<ECandidate>().AsQueryable());
            mockRepository.Setup(repo => repo.Add(It.IsAny<ECandidate>())).Returns(new ECandidate());

            var result = candidateService.AddOrUpdate(candidateVM);

            Assert.AreEqual(ResultStatus.Success, result.Status);
            Assert.AreEqual("Candidate added successfully.", result.Message);
            mockRepository.Verify(repo => repo.Add(It.IsAny<ECandidate>()), Times.Once);
        }

        [TestMethod]
        public void AddOrUpdate_UpdatesExistingCandidate_ReturnsSuccess()
        {
            // Arrange
            var candidateVM = new CandidateVM
            {
                Email = "existinguser@example.com",
                FirstName = "Updated",
                LastName = "User",
                PhoneNumber = "0987654321",
                CallTimeInterval = new TimeOnly(1, 4),
                LinkedInURL = "http://linkedin.com/updateduser",
                GitHubURL = "http://github.com/updateduser",
                FreeTextComment = "Updated candidate"
            };
            var existingCandidate = new ECandidate
            {
                Email = "existinguser@example.com",
                FirstName = "Existing",
                LastName = "User",
                PhoneNumber = "1234567890",
                CallTimeInterval = new TimeOnly(1, 4),
                LinkedInURL = "http://linkedin.com/existinguser",
                GitHubURL = "http://github.com/existinguser",
                FreeTextComment = "Existing candidate"
            };
            mockRepository.Setup(repo => repo.List()).Returns(new List<ECandidate> { existingCandidate }.AsQueryable());
            mockRepository.Setup(repo => repo.Update(It.IsAny<ECandidate>())).Returns(existingCandidate);

            var result = candidateService.AddOrUpdate(candidateVM);

            Assert.AreEqual(ResultStatus.Success, result.Status);
            Assert.AreEqual("Candidate updated successfully.", result.Message);
            mockRepository.Verify(repo => repo.Update(It.IsAny<ECandidate>()), Times.Once);
        }

        [TestMethod]
        public void Delete_DeletesExistingCandidate_ReturnsSuccess()
        {
            var email = "user@example.com";
            mockRepository.Setup(repo => repo.Delete(email)).Returns(1);

            var result = candidateService.Delete(email);

            Assert.AreEqual(ResultStatus.Success, result.Status);
            Assert.AreEqual("Candidate deleted successfully.", result.Message);
            mockRepository.Verify(repo => repo.Delete(email), Times.Once);
        }

        [TestMethod]
        public void Delete_CandidateNotFound_ReturnsFailure()
        {
            var email = "nonexistent@example.com";
            mockRepository.Setup(repo => repo.Delete(email)).Returns(0);

            var result = candidateService.Delete(email);

            Assert.AreEqual(ResultStatus.Failure, result.Status);
            Assert.AreEqual("Candidate not found.", result.Message);
            mockRepository.Verify(repo => repo.Delete(email), Times.Once);
        }

        [TestMethod]
        public void Get_RetrievesExistingCandidate_ReturnsSuccess()
        {
            var email = "user@example.com";
            var existingCandidate = new ECandidate
            {
                Email = email,
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890",
                CallTimeInterval = new TimeOnly(1, 4),
                LinkedInURL = "http://linkedin.com/user",
                GitHubURL = "http://github.com/user",
                FreeTextComment = "Candidate comment"
            };
            mockRepository.Setup(repo => repo.Find(email)).Returns(existingCandidate);

            var result = candidateService.Get(email);

            Assert.AreEqual(ResultStatus.Success, result.Status);
            Assert.AreEqual("Candidate retrieved successfully.", result.Message);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(email, result.Data.Email);
            mockRepository.Verify(repo => repo.Find(email), Times.Once);
        }

        [TestMethod]
        public void Get_CandidateNotFound_ReturnsFailure()
        {
            var email = "nonexistent@example.com";
            mockRepository.Setup(repo => repo.Find(email)).Returns((ECandidate)null);

            var result = candidateService.Get(email);

            Assert.AreEqual(ResultStatus.Failure, result.Status);
            Assert.AreEqual("Candidate not found.", result.Message);
            mockRepository.Verify(repo => repo.Find(email), Times.Once);
        }

        [TestMethod]
        public void List_RetrievesAllCandidates_ReturnsSuccess()
        {
            var candidates = new List<ECandidate>
            {
                new ECandidate
                {
                    Email = "user1@example.com",
                    FirstName = "First1",
                    LastName = "Last1",
                    PhoneNumber = "1234567890",
                    CallTimeInterval = new TimeOnly(1, 4),
                    LinkedInURL = "http://linkedin.com/user1",
                    GitHubURL = "http://github.com/user1",
                    FreeTextComment = "Candidate comment 1"
                },
                new ECandidate
                {
                    Email = "user2@example.com",
                    FirstName = "First2",
                    LastName = "Last2",
                    PhoneNumber = "0987654321",
                    CallTimeInterval = new TimeOnly(2, 5),
                    LinkedInURL = "http://linkedin.com/user2",
                    GitHubURL = "http://github.com/user2",
                    FreeTextComment = "Candidate comment 2"
                }
            };
            mockRepository.Setup(repo => repo.List()).Returns(candidates.AsQueryable());

            var result = candidateService.List();

            Assert.AreEqual(ResultStatus.Success, result.Status);
            Assert.AreEqual("Candidates retrieved successfully.", result.Message);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(2, result.Data.Count);
            mockRepository.Verify(repo => repo.List(), Times.Once);
        }
    }
}
