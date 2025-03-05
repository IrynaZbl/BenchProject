using Core.WebDriver;

namespace TestsUI
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Browser.GetInstance();
            Browser.MaximizeWindow();
            Browser.NavigateTo();
            Browser.Close();
        }
    }
}
