using Business.AppPageObjects;
using FluentAssertions;

namespace TestsUI
{
    [TestFixture]
    public class Tests : BaseTest
    {
        protected readonly AboutPage aboutPage = new AboutPage();
        protected readonly SearchPanel searchPanel = new SearchPanel();
        protected readonly SearchPage searchPage = new SearchPage();

        [Test]
        public void AboutMenuItemTest()
        {
            //Arrange
            var expectedTitle = "About";

            //Act
            homePage.GoToAboutPage();
            var actualTitle = aboutPage.GetTitle();

            //Assert
            actualTitle.Should().Be(expectedTitle);
        }

        [Test]
        public void SearchTest()
        {
            //Arrange
            var searchTerm = "Hello";

            //Act
            homePage.ClickSearch();
            searchPanel.EnterText(searchTerm);
            searchPanel.ClickFind();
            var actualNumberOfArticles = searchPage.GetNumberOfArticles();

            //Assert
            actualNumberOfArticles.Should().BeGreaterThan(0);
        }
    }
}
