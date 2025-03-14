using Business.AppPageObjects;
using Core.WebDriver;
using FluentAssertions;
using Xunit;

namespace TestsUI
{
    public class EpamTests_XUnit : IDisposable
    {
        protected Browser instance;
        private readonly HomePage homePage = new HomePage();
        private readonly AboutPage aboutPage = new AboutPage();
        private readonly SearchPanel searchPanel = new SearchPanel();
        private readonly SearchPage searchPage = new SearchPage();

        public EpamTests_XUnit()
        {
            instance = Browser.CreateInstance();
            instance.MaximizeWindow();
            instance.NavigateTo();
        }

        [Fact]
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

        [Fact]
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

        public void Dispose()
        {
            instance.Close();
        }
    }
}
