using Microsoft.Playwright;

namespace PWPages.Epam
{
    public class AboutPage : BasePage
    {
        public AboutPage(IPage page) : base(page) { }

        public async Task<string> GetTitle()
        {
            await page.WaitForLoadStateAsync();
            return await page.TitleAsync();
        }
    }
}
