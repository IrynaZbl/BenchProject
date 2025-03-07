using PWCore.WebDriver;
using PWPages.DemoQA;

namespace PWTests.UITests
{
    public class HomePageTests
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
            await _homePage.OpenAsync();
        }

        [Test]
        public async Task OpenHomePageTest()
        {           
            string title = await _homePage.GetPageTitleAsync();
            Assert.That(title, Is.EqualTo("DEMOQA"));
        }

        [Test]
        public async Task GoToElementsSectionTest()
        {
            var elementsPage = await _homePage.GoToElementsSectionAsync();
            string title = await elementsPage.GetPageTitleAsync();
            Assert.That(title, Is.EqualTo("DEMOQA"));
        }

        [Test]
        public async Task GoToFormsSectionTest()
        {
            var formsPage = await _homePage.GoToFormsSectionAsync();
            string title = await formsPage.GetPageTitleAsync();
            Assert.That(title, Is.EqualTo("DEMOQA"));
        }

        [Test]
        public async Task GoToWidgetsSectionTest()
        {
            var widgetsPage = await _homePage.GoToWidgetsSectionAsync();
            string title = await widgetsPage.GetPageTitleAsync();
            Assert.That(title, Is.EqualTo("DEMOQA"));
        }

        [TearDown]
        public async Task TearDown() => await _browser.Close();
    }
}
