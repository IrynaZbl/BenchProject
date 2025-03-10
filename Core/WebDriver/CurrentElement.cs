using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.WebDriver
{
    public class CurrentElement
    {
        private By locator;

        public CurrentElement(By locator)
        {
            this.locator = locator;
        }

        public void Click()
        {
            WaitForElementToBePresent()?.Click();
        }

        public List<CurrentElement> FindElements(By locator)
        {
            var results = WaitForElementToBePresent()?.FindElements(locator);
            var elements = new List<CurrentElement>();
            foreach (var result in results)
            {
                elements.Add(new CurrentElement(locator));
            }

            return elements;
        }

        public void SendKeys(string text)
        {
            WaitForElementToBePresent()?.SendKeys(text);
        }

        public string GetText()
        {
            return WaitForElementToBePresent()?.Text;
        }

        private IWebElement WaitForElementToBePresent()
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10));
            return wait.Until(drv =>
            {
                try
                {
                    var element = drv.FindElement(locator);
                    if (element != null && element.Displayed)
                        return element;
                }
                catch (NoSuchElementException)
                {
                    throw new Exception($"Element with locator '{locator}' was not found.");
                }

                return null;
            });
        }
    }}
