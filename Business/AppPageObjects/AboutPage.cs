using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class AboutPage : BasePage
    {
        private readonly CurrentElement pageTitle = new CurrentElement(By.XPath("//span[@class='rte-text-gradient']/span[text()='About']"));

        public AboutPage() : base() { }

        public string GetTitle()
        {
            return pageTitle.GetText();
        }
    }
}
