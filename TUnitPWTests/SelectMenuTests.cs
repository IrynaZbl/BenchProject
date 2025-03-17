using FluentAssertions;
using PWCore.WebDriver;
using PWPages.DemoQA;

namespace TUnitPWTests
{  
    public class SelectMenuTests
    {
        private Browser _browser;
        private BrowserConfig _config;
        private HomePage _homePage;

        [Before(Test)]
        public async Task Setup()
        {
            _config = BrowserConfig.Load();
            _browser = new Browser(_config);
            await _browser.InitializeAsync();
            _homePage = new HomePage(_browser.GetPage(), _config.BaseUrl);
            await _homePage.OpenAsync();
        }

        [Test]
        public async Task SelectValueDropdownTest()
        {
            var widgetsPage = await _homePage.GoToWidgetsSectionAsync();
            var selectMenuPage = await widgetsPage.GoToSelectMenuPageAsync();

            string expectedOption = "A root option";
            await selectMenuPage.SelectValueAsync(expectedOption);

            string selectedOption = await selectMenuPage.GetSelectedValueAsync();
            selectedOption.Should().Be(expectedOption);
        }

        [After(Test)]
        public async Task Cleanup()
        {
            await _browser.Close();
        }
    }
}
