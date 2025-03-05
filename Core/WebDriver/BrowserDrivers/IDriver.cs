using OpenQA.Selenium;

namespace Core.WebDriver.BrowserDrivers
{
    public interface IDriver
    {
        public IWebDriver Driver { get; }
    }
}
