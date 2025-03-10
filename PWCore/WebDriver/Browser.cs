using Microsoft.Playwright;
using PWCore.WebDriver.BrowserDrivers;

namespace PWCore.WebDriver
{
    public class Browser
    {
        private readonly IWebDriver _webDriver;
        private IPage _page;

        public Browser(BrowserConfig config)
        {
            _webDriver = WebDriverFactory.Create(config);
        }

        public async Task InitializeAsync()
        {
            await _webDriver.InitializeAsync();
            _page = _webDriver.GetPage();
        }

        public IPage GetPage() => _page;
        public async Task GoToUrl(string url) => await _page.GotoAsync(url);
        public async Task Click(string selector) => await _page.ClickAsync(selector);
        public async Task EnterText(string selector, string text) => await _page.FillAsync(selector, text);
        public async Task<string> GetText(string selector) => await _page.InnerTextAsync(selector);
        public async Task WaitForElement(string selector, int timeout = 5000) =>
            await _page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { Timeout = timeout });
        public async Task TakeScreenshot(string path) => await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path });
        public async Task Close() => await _webDriver.CloseAsync();
    }
}
