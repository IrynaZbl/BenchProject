using Business.AppPageObjects;
using Core.WebDriver;

namespace TestsUI
{
    public abstract class BaseTest
    {
        protected readonly HomePage homePage = new HomePage();
        protected readonly AboutPage aboutPage = new AboutPage();
        protected readonly SearchPanel searchPanel = new SearchPanel();
        protected readonly SearchPage searchPage = new SearchPage();

        [SetUp]
        public virtual void SetUp()
        {
            Browser.GetInstance();
            Browser.MaximizeWindow();
            Browser.NavigateTo();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Browser.Close();
        }
    }
}
