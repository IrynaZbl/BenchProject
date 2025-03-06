using Microsoft.Playwright;

namespace PWPages.DemoQA.MainPages
{
    public class SelectMenuPage
    {
        private readonly IPage _page;

        public SelectMenuPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToSelectMenuPageAsync()
        {
            await _page.ClickAsync("text=Select Menu");
        }

        public async Task SelectValueAsync(string option)
        {
            await _page.ClickAsync("#withOptGroup");
            await _page.ClickAsync($"text={option}");
        }

        public async Task<string> GetSelectedValueAsync()
        {
            return await _page.TextContentAsync("#withOptGroup .css-1uccc91-singleValue");
        }
    }
}
