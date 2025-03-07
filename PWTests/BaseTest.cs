using PWCore.WebDriver;

namespace PWTests
{
    public class BaseTests
    {
        private Browser _browser;
        private BrowserConfig _config;

        [SetUp]
        public async Task Setup()
        {
            _config = BrowserConfig.Load();
            _browser = new Browser(_config);
            await _browser.InitializeAsync();
        }

        [Test]
        public async Task BaseTest()
        {
            await _browser.GoToUrl("https://www.epam.com/");
            await _browser.Click("//div[@class='header__content']/child::a[@data-gtm-category='header-contact-cta']");
            await _browser.WaitForElement("//*[@class = 'museo-sans-light' and contains(text(), 'Contact Us')]");

            string welcomeText = await _browser.GetText("//*[@class = 'museo-sans-light' and contains(text(), 'Contact Us')]");
            Assert.That(welcomeText.Equals("Contact Us"));
        }

        [TearDown]
        public async Task TearDown() => await _browser.Close();
    }
}