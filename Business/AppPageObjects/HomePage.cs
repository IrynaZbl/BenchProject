using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class HomePage : BasePage
    {
        private readonly CustomElement aboutMenuItem = new CustomElement(By.XPath("//span/a[text()='About']"));
        private readonly CustomElement searchIcon = new CustomElement(By.XPath("//button[contains(@class,'header-search')]"));

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
