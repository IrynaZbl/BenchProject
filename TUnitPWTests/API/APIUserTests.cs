using FluentAssertions;
using System.Net;
using Newtonsoft.Json;
using APIFramework.Clients;
using APIFramework.Requests;
using APIFramework.Models;
using Newtonsoft.Json.Linq;

namespace TUnitPWTests.API
{
    public class UserTests : BaseApiTest
    {
        private static UserRequests _userRequests;
        private string _responseContent;
        private UserModel _user;

        [Before(Class)]
        public static void SetupUserTests()
        {
            _userRequests = new UserRequests(_client);
        }

        [Before(Test)]
        public async Task SetupTest()
        {
            var response = await _userRequests.GetUserAsync();
            _responseContent = response.Content;
            _user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(_responseContent);
        }

        [Test]
        public async Task StatusCode_ShouldBe_200OK()
        {
            var response = await _userRequests.GetUserAsync();
            await ValidateStatusCodeAsync(response, HttpStatusCode.OK);
        }

        [Test]
        public void ResponseContent_ShouldNotBe_Empty()
        {
            ValidateResponseNotEmpty(_responseContent);
        }

        [Test]
        public void UserLogin_ShouldNotBe_Empty()
        {
            _user.Should().NotBeNull();
            _user.Login.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void UserId_ShouldBe_Positive()
        {
            _user.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void AvatarUrl_ShouldStartWith_Https()
        {
            _user.AvatarUrl.Should().StartWith("https://");
        }

        [Test]
        public void Response_ShouldContain_ExpectedFields()
        {
            JObject json = JObject.Parse(_responseContent);
            ValidateJsonField(json, "login");
            ValidateJsonField(json, "id");
            ValidateJsonField(json, "avatar_url");
        }
    }
}
