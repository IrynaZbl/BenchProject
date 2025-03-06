using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Core.WebDriver
{
    public class BaseElement : IWebElement
    {
        protected By locator;

        public BaseElement(By pointer)
        {
            locator = pointer;
        }

        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            WaitForElementToBePresent()?.Click();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            WaitForElementToBePresent();
            return Browser.Driver.FindElements(locator);
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            var element = WaitForElementToBePresent();
            element.Clear();
            element.SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public string GetText()
        {
            return WaitForElementToBePresent().FindElement(locator).Text;
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
                    Console.WriteLine("WaitForElementToBePresent method: 'NoSuchElementException' is found.");
                }

                return null;
            });
        }
    }
}
