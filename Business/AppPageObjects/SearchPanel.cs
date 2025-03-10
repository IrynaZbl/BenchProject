using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class SearchPanel : BasePage
    {
        private readonly CustomElement searchInput = new CustomElement(By.Id("new_form_search"));
        private readonly CustomElement findButton = new CustomElement(By.ClassName("bth-text-layer"));

        public SearchPanel() : base() { }

        public void EnterText(string text)
        {
            searchInput.SendKeys(text);
        }

        public void ClickFind()
        {
            findButton.Click();
        }
    }
}
