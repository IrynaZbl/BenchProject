using APIFramework.Clients;
using RestSharp;

namespace APIFramework.Requests
{
    public class UserRequests
    {
        private readonly GitHubApiClient _client;

        public UserRequests(GitHubApiClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> GetUserAsync()
        {
            return await _client.SendRequestAsync("/user", Method.Get);
        }
    }
}
