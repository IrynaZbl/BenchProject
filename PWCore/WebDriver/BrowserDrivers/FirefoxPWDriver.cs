using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCore.WebDriver.BrowserDrivers
{
    public class FirefoxPWDriver : IWebDriver
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private BrowserConfig _config;

        public FirefoxPWDriver(BrowserConfig config)
        {
            _config = config;
        }

        public async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = _config.Headless,
                SlowMo = _config.SlowMo,
                Timeout = _config.Timeout
            });
            _page = await _browser.NewPageAsync();
        }

        public IPage GetPage() => _page;

        public async Task CloseAsync() => await _browser.CloseAsync();
    }
}
