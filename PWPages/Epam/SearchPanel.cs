using Microsoft.Playwright;

namespace PWPages.Epam
{
    public class SearchPanel : BasePage
    {
        private readonly string searchInput = "//*[@id='new_form_search']";
        private readonly string findButton = "//*[@class='bth-text-layer']";

        public SearchPanel(IPage page) : base(page) { }

        public async Task EnterText(string text)
        {
            await page.FillAsync(searchInput, text);
        }

        public async Task<SearchPage> ClickFind()
        {
            await page.ClickAsync(findButton);
            return new SearchPage(page);
        }
    }
}
