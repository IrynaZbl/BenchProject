using Core.WebDriver;
using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public class SearchPage : BasePage
    {
        private static readonly By articleLocator = By.XPath("//div[contains(@class,'search-results')]/article");
        private readonly CustomElement results = new CustomElement(By.XPath("//h2[contains(@class,'search-results')]"));

        public SearchPage() : base() { }

        public int GetNumberOfArticles()
        {
            return results.FindElements(articleLocator).Count;
        }
    }
}
