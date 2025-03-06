using PWCore.WebDriver.BrowserDrivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCore.WebDriver
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create(BrowserConfig config)
        {
            return config.Browser.ToLower() switch
            {
                "chromium" => new ChromePWDriver(config),
                "firefox" => new FirefoxPWDriver(config),
                _ => throw new System.Exception($"Unsupported browser type: {config.Browser}")
            };
        }
    }
}
