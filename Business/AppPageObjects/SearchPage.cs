using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class SearchPage : BasePage
    {
        private static readonly By pageTitleLocator = By.XPath("//span[contains(@class,'rte-text-gradient')][text()='Search']");
        private static readonly By articleLocator = By.XPath("//div[contains(@class,'earch-results')]/article");

        public SearchPage() : base(pageTitleLocator) { }

        private readonly BaseElement article = new BaseElement(articleLocator);

        public int GetNumberOfArticles()
        {
            return article.FindElements(articleLocator).Count;
        }
    }
}
