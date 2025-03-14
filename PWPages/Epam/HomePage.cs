using Microsoft.Playwright;

namespace PWPages.Epam
{
    public class HomePage : BasePage
    {
        private readonly string aboutMenuItem = "//span/a[text()='About']";
        private readonly string searchIcon = "//button[contains(@class,'header-search')]";

        public HomePage(IPage page, string baseUrl) : base(page, baseUrl) { }

        public async Task Open()
        {
            await page.GotoAsync(baseUrl);
        }

        public async Task<AboutPage> GoToAboutPage()
        {
            await page.ClickAsync(aboutMenuItem);
            return new AboutPage(page);
        }

        public async Task<SearchPanel> ClickSearch()
        {
            await page.ClickAsync(searchIcon);
            return new SearchPanel(page);
        }
    }
}
