using Microsoft.Playwright;

namespace PWPages.DemoQA.SectionPages
{
    public class FormsPage : SectionPage
    {
        public FormsPage(IPage page) : base(page) { }
        public async Task GoToPracticeFormSectionAsync()
        {
            await ClickTabAsync("Practice Form");
        }
    }
}
