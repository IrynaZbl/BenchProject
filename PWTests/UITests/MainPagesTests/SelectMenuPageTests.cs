using PWCore.WebDriver;
using PWPages.DemoQA;

namespace PWTests.UITests.MainPagesTests
{
    public class SelectMenuTests
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
        public async Task SelectValueDropdownTest()
        {
            await _homePage.OpenAsync();
            var widgetsPage = await _homePage.GoToWidgetsSectionAsync();
            var selectMenuPage = await widgetsPage.GoToSelectMenuPageAsync();

            string expectedOption = "A root option";
            await selectMenuPage.SelectValueAsync(expectedOption);

            string selectedOption = await selectMenuPage.GetSelectedValueAsync();
            Assert.That(selectedOption, Is.EqualTo(expectedOption));
        }

        [TearDown]
        public async Task TearDown() => await _browser.Close();
    }
}
