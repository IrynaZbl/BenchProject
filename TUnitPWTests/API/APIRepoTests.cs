using System.Net;
using APIFramework.Requests;
using Newtonsoft.Json.Linq;

namespace TUnitPWTests.API
{
    public class RepoTests : BaseApiTest
    {
        private static RepoRequests _repoRequests;
        private string _responseContent;
        private JArray _repos;

        [Before(Class)]
        public static void SetupRepoTests()
        {
            _repoRequests = new RepoRequests(_client);
        }

        [Before(Test)]
        public async Task SetupTest()
        {
            var response = await _repoRequests.GetRepositoriesAsync();
            _responseContent = response.Content;
            _repos = JArray.Parse(_responseContent);
        }

        [Test]
        public async Task StatusCode_ShouldBe_200OK()
        {
            var response = await _repoRequests.GetRepositoriesAsync();
            await ValidateStatusCodeAsync(response, HttpStatusCode.OK);
        }

        [Test]
        public void ResponseContent_ShouldNotBe_Empty()
        {
            ValidateResponseNotEmpty(_responseContent);
        }

        [Test]
        public void ShouldHave_AtLeastOneRepository()
        {
            ValidateJsonArrayHasItems(_repos, "repositories");
        }

        [Test]
        public void Repositories_ShouldContain_ExpectedFields()
        {
            foreach (var repo in _repos)
            {
                ValidateJsonField((JObject)repo, "name");
                ValidateJsonField((JObject)repo, "full_name");
                ValidateJsonField((JObject)repo, "owner");
            }
        }
    }
}
