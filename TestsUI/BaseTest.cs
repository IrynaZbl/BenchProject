using Business.AppPageObjects;
using Core.WebDriver;

namespace TestsUI
{
    public abstract class BaseTest
    {
        protected Browser instance;
        protected readonly HomePage homePage = new HomePage();

        [SetUp]
        public virtual void SetUp()
        {
            instance = Browser.CreateInstance();
            instance.MaximizeWindow();
            instance.NavigateTo();
        }

        [TearDown]
        public virtual void TearDown()
        {
            instance.Close();
        }
    }
}
