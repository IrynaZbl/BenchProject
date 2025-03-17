using APIFramework.Requests;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TUnitPWTests.API
{
    public class RepoManagementTests : BaseApiTest
    {
        private static RepoRequests _repoRequests;
        private string _repoName;
        private const string RepoDescription = "This is a test repository.";

        [Before(Class)]
        public static void SetupRepoRequests()
        {
            _repoRequests = new RepoRequests(_client);
        }

        [Before(Test)]
        public void GenerateRepoName()
        {
            _repoName = $"test-repo-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }

        [Test]
        public async Task CreateRepository_ShouldReturn_201Created()
        {
            var response = await _repoRequests.CreateRepositoryAsync(_repoName, RepoDescription);
            await ValidateStatusCodeAsync(response, HttpStatusCode.Created);

            var json = JObject.Parse(response.Content);
            json["name"].ToString().Should().Be(_repoName);
        }

        [Test]
        public async Task UpdateRepository_ShouldReturn_200OK()
        {
            var createResponse = await _repoRequests.CreateRepositoryAsync(_repoName, RepoDescription);
            await ValidateStatusCodeAsync(createResponse, HttpStatusCode.Created);

            string newDescription = "Updated repository description.";
            var updateResponse = await _repoRequests.UpdateRepositoryAsync(_repoName, newDescription);
            await ValidateStatusCodeAsync(updateResponse, HttpStatusCode.OK);

            var json = JObject.Parse(updateResponse.Content);
            json["description"].ToString().Should().Be(newDescription);
        }

        [Test]
        public async Task DeleteRepository_ShouldReturn_204NoContent()
        {
            var createResponse = await _repoRequests.CreateRepositoryAsync(_repoName, RepoDescription);
            await ValidateStatusCodeAsync(createResponse, HttpStatusCode.Created);

            var deleteResponse = await _repoRequests.DeleteRepositoryAsync(_repoName);
            await ValidateStatusCodeAsync(deleteResponse, HttpStatusCode.NoContent);

            _repoName = null;
        }

        [After(Test)]
        public async Task Cleanup()
        {
            if (!string.IsNullOrEmpty(_repoName))
            {
                Console.WriteLine($"Cleaning up: Deleting repository {_repoName}");
                await _repoRequests.DeleteRepositoryAsync(_repoName);
            }
        }
    }
}
