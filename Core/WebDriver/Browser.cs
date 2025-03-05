using OpenQA.Selenium;
using static Core.WebDriver.WebDriverFactory;

namespace Core.WebDriver
{
    public sealed class Browser
    {
        public static IWebDriver Driver { get; private set; }
        private static readonly Browser instance = new Browser();

        static Browser()
        {
        }

        private Browser()
        {
            Driver = BrowserFactory.GetDriver(Configuration.BrowserType);
        }

        public static Browser GetInstance()
        {
            return instance;
        }

        public static void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Configuration.AppUrl);
        }

        public static void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
