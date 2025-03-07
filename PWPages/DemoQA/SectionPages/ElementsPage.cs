using Microsoft.Playwright;
using PWPages.DemoQA.MainPages;

namespace PWPages.DemoQA.SectionPages
{
    public class ElementsPage : SectionPage
    {
        public ElementsPage(IPage page) : base(page) { }

        public async Task<TextBoxPage> GoToTextBoxSectionAsync()
        {
            await ClickTabAsync("Text Box");
            return new TextBoxPage(_page);
        }
    }
}
