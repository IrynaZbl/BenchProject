using RestSharp;
using Newtonsoft.Json.Linq;

namespace APIFramework.Clients
{
    public class GitHubApiClient
    {
        private readonly string _url = "https://api.github.com";
        private readonly RestClient _client;
        private readonly string _accessToken;

        public GitHubApiClient()
        {
            _accessToken = LoadSecret("Configs/secrets.json", "GitHubAccessToken");

            if (string.IsNullOrEmpty(_accessToken))
                throw new Exception("GitHub Access Token is missing! Check your secrets.json file.");

            _client = new RestClient(_url);
        }

        private string LoadSecret(string filePath, string key)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Secret file '{filePath}' not found!");

            var json = File.ReadAllText(filePath);
            var obj = JObject.Parse(json);
            return obj[key]?.ToString();    
        }

        public async Task<string> GetUsername()
        {
            var response = await SendRequestAsync("/user", Method.Get);
            var json = JObject.Parse(response.Content);
            return json["login"].ToString();
        }

        public async Task<RestResponse> SendRequestAsync(string endpoint, Method method)
        {
            var request = new RestRequest(endpoint, method)
                .AddHeader("Authorization", $"Bearer {_accessToken}")
                .AddHeader("User-Agent", "CSharp-API-Test");

            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> SendRequestAsync(RestRequest request)
        {
            request.AddHeader("Authorization", $"Bearer {_accessToken}");
            request.AddHeader("User-Agent", "CSharp-API-Test");

            return await _client.ExecuteAsync(request);
        }

        public string GetAccessToken() => _accessToken;
    }
}
