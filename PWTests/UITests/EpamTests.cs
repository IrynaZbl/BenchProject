using FluentAssertions;
using PWPages.Epam;

namespace PWTests.UITests
{
    [TestFixture]
    public class EpamTests : BaseTests
    {
        private HomePage homePage;

        [SetUp]
        public async Task SetUp()
        {
            var baseUrl = _config.BaseUrl;
            homePage = new HomePage(_browser.GetPage(), _config.BaseUrl);
            await homePage.Open();
        }

        [Test]
        public async Task AboutMenuItemTest()
        {
            //Arrange
            var expectedTitle = "About EPAM";

            //Act
            var aboutPage = await homePage.GoToAboutPage();
            var actualTitle = aboutPage.GetTitle().Result;

            //Assert
            actualTitle.Should().Contain(expectedTitle);
        }

        [Test]
        public async Task SearchTest()
        {
            //Arrange
            var searchTerm = "Hello";

            //Act
            var searchPanel = await homePage.ClickSearch();
            await searchPanel.EnterText(searchTerm);
            var searchPage = await searchPanel.ClickFind();
            var actualNumberOfArticles = await searchPage.GetNumberOfArticles();

            //Arrange
            actualNumberOfArticles.Should().BeGreaterThan(0);
        }
    }
}
