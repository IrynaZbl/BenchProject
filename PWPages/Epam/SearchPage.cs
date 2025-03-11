using Microsoft.Playwright;

namespace PWPages.Epam
{
    public class SearchPage : BasePage
    {
        private readonly string article = "//div[contains(@class,'earch-results')]/article";

        public SearchPage(IPage page) : base(page) { }

        public async Task<int> GetNumberOfArticles()
        {
            var articles = page.Locator(article);
            await articles.Last.WaitForAsync();
            return await articles.CountAsync();
        }
    }
}
