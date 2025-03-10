using Microsoft.Playwright;
using PWPages.DemoQA.SectionPages;

namespace PWPages.DemoQA
{
    public class HomePage
    {
        private readonly IPage _page;
        private readonly string _baseUrl;

        public HomePage(IPage page, string baseUrl)
        {
            _page = page;
            _baseUrl = baseUrl;
        }

        public async Task OpenAsync()
        {
            await _page.GotoAsync(_baseUrl);
        }

        public async Task<string> GetPageTitleAsync()
        {
            return await _page.TitleAsync();
        }

        public async Task<ElementsPage> GoToElementsSectionAsync()
        {
            await _page.ClickAsync("h5:has-text('Elements')");
            return new ElementsPage(_page);
        }

        public async Task<FormsPage> GoToFormsSectionAsync()
        {
            await _page.ClickAsync("h5:has-text('Forms')");
            return new FormsPage(_page);
        }
        public async Task<WidgetsPage> GoToWidgetsSectionAsync()
        {
            await _page.ClickAsync("h5:has-text('Widgets')");
            return new WidgetsPage(_page);
        }
    }
}
