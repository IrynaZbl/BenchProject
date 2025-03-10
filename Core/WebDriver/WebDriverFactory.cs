using Core.WebDriver.BrowserDrivers;
using OpenQA.Selenium;

namespace Core.WebDriver
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetDriver(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        return new ChromeBrowserDriver().Driver;
                    }
                case BrowserType.Firefox:
                    {
                        return new FirefoxBrowserDriver().Driver;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox
    }
}
