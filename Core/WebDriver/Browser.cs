using OpenQA.Selenium;
using static Core.WebDriver.WebDriverFactory;

namespace Core.WebDriver
{
    public class Browser
    {
        public static IWebDriver Driver { get; private set; }
        private static readonly Browser instance = new Browser();

        private Browser()
        {
            Driver = BrowserFactory.GetDriver(Configuration.BrowserType);
        }

        public static Browser CreateInstance()
        {
            return instance;
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Configuration.AppUrl);
        }

        public void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public void Close()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
