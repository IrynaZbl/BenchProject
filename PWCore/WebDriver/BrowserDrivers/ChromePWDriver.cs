using Microsoft.Playwright;
using System.Drawing;

namespace PWCore.WebDriver.BrowserDrivers
{
    public class ChromePWDriver : IWebDriver
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private BrowserConfig _config;

        public ChromePWDriver(BrowserConfig config)
        {
            _config = config;
        }

        public async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = _config.Headless,
                SlowMo = _config.SlowMo,
                Timeout = _config.Timeout,
                Args = new[] { "--start-maximized" }
            });

            _page = await _browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });
        }

        public IPage GetPage() => _page;

        public async Task CloseAsync() => await _browser.CloseAsync();
    }
}
