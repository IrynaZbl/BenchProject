using FluentAssertions;
using PWCore.WebDriver;
using PWPages.DemoQA;

namespace PWTests.UITests.MainPagesTests
{
    public class TextBoxTests
    {
        private Browser _browser;
        private BrowserConfig _config;
        private HomePage _homePage;

        [SetUp]
        public async Task Setup()
        {
            _config = BrowserConfig.Load();
            _browser = new Browser(_config);
            await _browser.InitializeAsync();
            _homePage = new HomePage(_browser.GetPage(), _config.BaseUrl);
        }

        [Test]
        public async Task FillTextBoxFormTest()
        {
            await _homePage.OpenAsync();
            var elementsPage = await _homePage.GoToElementsSectionAsync();
            var textBoxPage = await elementsPage.GoToTextBoxSectionAsync();

            string fullName = "John Doe";
            string email = "john.doe@example.com";
            string currentAddress = "123 Current St.";
            string permanentAddress = "456 Permanent Ave.";

            await textBoxPage.EnterFullNameAsync(fullName);
            await textBoxPage.EnterEmailAsync(email);
            await textBoxPage.EnterCurrentAddressAsync(currentAddress);
            await textBoxPage.EnterPermanentAddressAsync(permanentAddress);

            await textBoxPage.ClickSubmitAsync();

            (await textBoxPage.GetResultTextAsync("name")).Should().Contain(fullName);
            (await textBoxPage.GetResultTextAsync("email")).Should().Contain(email);
            (await textBoxPage.GetResultTextAsync("currentAddress")).Should().Contain(currentAddress);
            (await textBoxPage.GetResultTextAsync("permanentAddress")).Should().Contain(permanentAddress);
        }

        [TearDown]
        public async Task TearDown() => await _browser.Close();
    }
}
