using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class SearchPanel : BasePage
    {
        private static readonly By panelTitleLocator = By.XPath("//span[contains(@class,'header-search')][text()='Search']");

        public SearchPanel() : base(panelTitleLocator) { }

        private readonly BaseElement searchInput = new BaseElement(By.Id("new_form_search"));
        private readonly BaseElement findButton = new BaseElement(By.ClassName("bth-text-layer"));

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
