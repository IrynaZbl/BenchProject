using Microsoft.Playwright;
using PWPages.DemoQA.MainPages;

namespace PWPages.DemoQA.SectionPages
{
    public class WidgetsPage : SectionPage
    {
        public WidgetsPage(IPage page) : base(page) { }

        public async Task GoToAccordianSectionAsync()
        {
            await ClickTabAsync("Accordian");
        }

        public async Task<SelectMenuPage> GoToSelectMenuPageAsync()
        {
            await ClickTabAsync("Select Menu");
            return new SelectMenuPage(_page);
        }
    }
}
