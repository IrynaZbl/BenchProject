using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PlaywrightDriver
    {
        private static IPlaywright? _playwright;
        private static IBrowser? _browser;
        private IPage? _page;

        public static async Task<PlaywrightDriver> CreateAsync(BrowserTypeLaunchOptions options = null)
        {
            if (_playwright == null)
            {
                _playwright = await Playwright.CreateAsync();
                _browser = await _playwright.Chromium.LaunchAsync(options ?? new BrowserTypeLaunchOptions { Headless = false });
            }
            return new PlaywrightDriver();
        }

        private PlaywrightDriver()
        {
            _page = _browser.NewPageAsync().Result;
        }

        public async Task GoToUrlAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task<IElementHandle> FindElementAsync(string selector)
        {
            return await _page.QuerySelectorAsync(selector);
        }

        public async Task<IReadOnlyList<IElementHandle>> FindElementsAsync(string selector)
        {
            return await _page.QuerySelectorAllAsync(selector);
        }

        public async Task ClickAsync(string selector)
        {
            await _page.ClickAsync(selector);
        }

        public async Task EnterTextAsync(string selector, string text)
        {
            await _page.FillAsync(selector, text);
        }

        public async Task<string> GetTextAsync(string selector)
        {
            return await _page.InnerTextAsync(selector);
        }

        public async Task WaitForElementAsync(string selector, int timeout = 5000)
        {
            await _page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { Timeout = timeout });
        }

        public async Task TakeScreenshotAsync(string path)
        {
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path });
        }

        public async Task CloseAsync()
        {
            await _page.CloseAsync();
        }
        public static async Task DisposeAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
                _playwright?.Dispose();
                _playwright = null;
                _browser = null;
            }
        }
    }
}
