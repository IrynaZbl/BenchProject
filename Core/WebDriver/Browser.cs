using OpenQA.Selenium;

namespace Core.WebDriver
{
    public class Browser
    {
        public static IWebDriver Driver { get; private set; }
        private static Browser instance;

        private Browser()
        {
            Driver = WebDriverFactory.GetDriver(Configuration.BrowserType);
        }

        public static Browser CreateInstance()
        {
            return instance ?? (instance = new Browser());
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
            instance = null;
        }
    }
}
