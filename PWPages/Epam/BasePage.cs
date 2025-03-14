using Microsoft.Playwright;

namespace PWPages.Epam
{
    public abstract class BasePage
    {
        protected readonly IPage page;
        protected readonly string baseUrl;

        protected BasePage(IPage page)
        {
            this.page = page;
        }

        protected BasePage(IPage page, string baseUrl)
        {
            this.page = page;
            this.baseUrl = baseUrl;
        }
    }
}
