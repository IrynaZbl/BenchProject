using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.WebDriver.BrowserDrivers
{
    public class ChromeBrowserDriver : IDriver
    {
        public IWebDriver Driver
        {
            get
            {
                var service = ChromeDriverService.CreateDefaultService();
                var options = new ChromeOptions();
                options.AddArgument("disable-infobars");
                options.AddArgument("--no-sandbox");
                return new ChromeDriver(service, options);
            }
        }
    }
}
