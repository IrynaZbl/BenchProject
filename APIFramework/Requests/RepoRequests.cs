using APIFramework.Clients;
using RestSharp;

namespace APIFramework.Requests
{
    public class RepoRequests
    {
        private readonly GitHubApiClient _client;

        public RepoRequests(GitHubApiClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> GetRepositoriesAsync()
        {
            return await _client.SendRequestAsync("/user/repos", Method.Get);
        }
        public async Task<RestResponse> CreateRepositoryAsync(string repoName, string description)
        {
            var request = new RestRequest("/user/repos", Method.Post)
                .AddJsonBody(new { name = repoName, description = description, @private = false });

            return await _client.SendRequestAsync(request);
        }

        public async Task<RestResponse> GetRepositoryAsync(string repoName)
        {
            string username = await _client.GetUsername();
            var request = new RestRequest($"/repos/{username}/{repoName}", Method.Get);

            return await _client.SendRequestAsync(request);
        }

        public async Task<RestResponse> UpdateRepositoryAsync(string repoName, string newDescription)
        {
            string username = await _client.GetUsername();
            var request = new RestRequest($"/repos/{username}/{repoName}", Method.Patch)
                .AddJsonBody(new { description = newDescription });

            return await _client.SendRequestAsync(request);
        }

        public async Task<RestResponse> DeleteRepositoryAsync(string repoName)
        {
            string username = await _client.GetUsername();
            var request = new RestRequest($"/repos/{username}/{repoName}", Method.Delete);

            return await _client.SendRequestAsync(request);
        }
    }
}
