using PWCore.WebDriver;

namespace PWTests
{
    public abstract class BaseTests
    {
        protected Browser _browser;
        protected BrowserConfig _config;

        [SetUp]
        public async Task Setup()
        {
            _config = BrowserConfig.Load();
            _browser = new Browser(_config);
            await _browser.InitializeAsync();
        }

        [TearDown]
        public async Task TearDown() => await _browser.Close();
    }
}