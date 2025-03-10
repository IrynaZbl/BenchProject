using Business.AppPageObjects;
using Core.WebDriver;

namespace TestsUI
{
    public abstract class BaseTest
    {
        protected Browser instance = Browser.CreateInstance();
        protected readonly HomePage homePage = new HomePage();

        [SetUp]
        public virtual void SetUp()
        {
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
