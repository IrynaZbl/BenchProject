using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PWCore.WebDriver.BrowserDrivers
{
    public interface IWebDriver
    {
        Task InitializeAsync();
        IPage GetPage();
        Task CloseAsync();
    }
}
