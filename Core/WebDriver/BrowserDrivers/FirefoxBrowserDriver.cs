using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Core.WebDriver.BrowserDrivers
{
    public class FirefoxBrowserDriver : IDriver
    {
        public IWebDriver Driver
        {
            get
            {
                var service = FirefoxDriverService.CreateDefaultService();
                var options = new FirefoxOptions();
                return new FirefoxDriver(service, options);
            }
        }
    }
}
