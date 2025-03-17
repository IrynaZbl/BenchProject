using APIFramework.Clients;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace TUnitPWTests.API
{
    public abstract class BaseApiTest
    {
        protected static GitHubApiClient _client;

        [Before(Class)] // ✅ Runs once per test class (Static)
        public static void SetupClass()
        {
            _client = new GitHubApiClient();
        }

        protected async Task ValidateStatusCodeAsync(RestResponse response, HttpStatusCode expectedStatus)
        {
            response.StatusCode.Should().Be(expectedStatus, $"Expected status {expectedStatus}, but got {response.StatusCode}");
        }

        protected void ValidateResponseNotEmpty(string responseContent)
        {
            responseContent.Should().NotBeNullOrEmpty("Response content should not be empty");
        }

        protected void ValidateJsonField(JObject json, string fieldName)
        {
            json.Should().ContainKey(fieldName, $"Response should contain field '{fieldName}'");
        }

        protected void ValidateJsonArrayHasItems(JArray jsonArray, string arrayName)
        {
            jsonArray.Count.Should().BeGreaterThan(0, $"Expected at least one item in '{arrayName}' array");
        }

        [After(Class)] // ✅ Runs once after all tests in the class
        public static void Cleanup()
        {
            _client = null;
        }
    }
}
