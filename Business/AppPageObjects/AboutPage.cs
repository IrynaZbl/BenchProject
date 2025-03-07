using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class AboutPage : BasePage
    {
        private static readonly By pageTitleLocator = By.XPath("//span[@class='rte-text-gradient']/span[text()='About']");

        public AboutPage() : base(pageTitleLocator) { }

        private readonly BaseElement pageTitle = new BaseElement(pageTitleLocator);

        public string GetTitle()
        {
            return pageTitle.GetText();
        }
    }
}
