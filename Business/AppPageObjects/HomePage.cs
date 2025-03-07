using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class HomePage : BasePage
    {
        private static readonly By epamIconLocator = By.ClassName("logo-print");

        public HomePage() : base(epamIconLocator) { }

        private readonly BaseElement aboutMenuItem = new BaseElement(By.XPath("//span/a[text()='About']"));
        private readonly BaseElement searchIcon = new BaseElement(By.XPath("//button[contains(@class,'header-search')]"));

        public void GoToAboutPage()
        {
            aboutMenuItem.Click();
        }

        public void ClickSearch()
        {
            searchIcon.Click();
        }
    }
}
