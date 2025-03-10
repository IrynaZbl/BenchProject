using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class HomePage : BasePage
    {
        private readonly CurrentElement aboutMenuItem = new CurrentElement(By.XPath("//span/a[text()='About']"));
        private readonly CurrentElement searchIcon = new CurrentElement(By.XPath("//button[contains(@class,'header-search')]"));

        public HomePage() : base() { }

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
