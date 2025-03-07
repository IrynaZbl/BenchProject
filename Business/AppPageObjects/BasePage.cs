using OpenQA.Selenium;

namespace Business.AppPageObjects
{
    public abstract class BasePage
    {
        protected By locator;

        protected BasePage(By locator)
        {
            this.locator = locator;
        }
    }
}
