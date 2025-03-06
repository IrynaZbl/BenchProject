using Microsoft.Playwright;

namespace PWPages.DemoQA.SectionPages
{
    public abstract class SectionPage
    {
        protected readonly IPage _page;

        protected SectionPage(IPage page)
        {
            _page = page;
        }

        public async Task<string> GetPageTitleAsync()
        {
            return await _page.TitleAsync();
        }

        protected async Task<bool> IsTabVisibleAsync(string tabName)
        {
            return await _page.IsVisibleAsync($"//span[text()='{tabName}']");
        }

        protected async Task ClickTabAsync(string tabName)
        {
            await _page.ClickAsync($"//span[text()='{tabName}']");
        }
    }
}
