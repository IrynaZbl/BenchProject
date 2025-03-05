using Core;

namespace PWTests
{
    public class BaseTests
    {
        private PlaywrightDriver _driver;

        [SetUp]
        public async Task Setup()
        {
            _driver = await PlaywrightDriver.CreateAsync();
        }

        [Test]
        public async Task BaseTest()
        {
            await _driver.GoToUrlAsync("https://www.epam.com/");
            await _driver.ClickAsync("//div[@class='header__content']/child::a[@data-gtm-category='header-contact-cta']");
            await _driver.WaitForElementAsync("//*[@class = 'museo-sans-light' and contains(text(), 'Contact Us')]");

            string welcomeText = await _driver.GetTextAsync("//*[@class = 'museo-sans-light' and contains(text(), 'Contact Us')]");
            Assert.AreEqual("Contact Us", welcomeText);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _driver.CloseAsync();
            await PlaywrightDriver.DisposeAsync();
        }
    }
}