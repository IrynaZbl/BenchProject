using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class SearchPanel : BasePage
    {
        private readonly CurrentElement searchInput = new CurrentElement(By.Id("new_form_search"));
        private readonly CurrentElement findButton = new CurrentElement(By.ClassName("bth-text-layer"));

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
