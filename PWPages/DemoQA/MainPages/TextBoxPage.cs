using Microsoft.Playwright;

namespace PWPages.DemoQA.MainPages
{
    public class TextBoxPage
    {
        private readonly IPage _page;

        public TextBoxPage(IPage page)
        {
            _page = page;
        }

        public async Task EnterFullNameAsync(string fullName)
        {
            await _page.FillAsync("#userName", fullName);
        }

        public async Task EnterEmailAsync(string email)
        {
            await _page.FillAsync("#userEmail", email);
        }

        public async Task EnterCurrentAddressAsync(string address)
        {
            await _page.FillAsync("#currentAddress", address);
        }

        public async Task EnterPermanentAddressAsync(string address)
        {
            await _page.FillAsync("#permanentAddress", address);
        }

        public async Task ClickSubmitAsync()
        {
            await _page.ClickAsync("#submit");
            await _page.WaitForSelectorAsync(".border");
        }

        public async Task<string> GetResultTextAsync(string fieldId)
        {
            return await _page.TextContentAsync($"#output #{fieldId}");
        }
    }
}