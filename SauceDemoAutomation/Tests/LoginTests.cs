using OpenQA.Selenium;
using SauceDemoAutomation.Core;
using SauceDemoAutomation.Pages;
using FluentAssertions;
using SauceDemoAutomation.Utilities;
using Xunit;



namespace SauceDemoAutomation.Tests
{
    [Collection("Parallel Tests")]
    public class LoginTests
    {
        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]


        public void UC1_LoginWithEmptyCredentials_ShowsErrorMessage_EmptyUsername(string browser)
        {
            Logger.Info($"Starting Test UC1 on {browser} and navegating to the Web");
            var driver = DriverFactory.InitializeDriver(browser);
            var loginPage = new LoginPage();

            Logger.Info("Entering username and password");
            loginPage.EnterUsername("usernameTest");
            loginPage.EnterPassword("passwordTest");

            Logger.Info("Clearing username and password ");
            loginPage.ClearUsername();
            loginPage.ClearPassword();

            Logger.Info("Clicking login button");
            loginPage.ClickLogin();

            Logger.Info("Validating error message for empty username");
            loginPage.GetErrorMessage().Should().Be("Epic sadface: Username is required");

            Logger.Info("Test finished successfully");
            driver.Quit();
        }

        [Theory]
        [InlineData("chrome", "standard_user", "Test")]
        [InlineData("firefox", "standard_user", "Test")]

        public void UC2_LoginWithInvalidCredentials_ShowsErrorMessage_EmptyPassword(string browser, string username, string password)
        {
            Logger.Info($"Starting Test UC2 on {browser} and navegating to the Web");
            var driver = DriverFactory.InitializeDriver(browser);
            var loginPage = new LoginPage();

            Logger.Info("Entering username and password");
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);

            Logger.Info("Clearing password");
            loginPage.ClearPassword();

            Logger.Info("Clicking login button");
            loginPage.ClickLogin();

            Logger.Info("Validating error message for empty password");
            loginPage.GetErrorMessage().Should().Be("Epic sadface: Password is required");

            Logger.Info("Test finished successfully");
            driver.Quit();

        }

        [Theory]
        [InlineData("chrome", "standard_user", "secret_sauce")]
        [InlineData("firefox", "standard_user", "secret_sauce")]

        public void UC3_LoginWithValidCredentials_ValidatesSuccessfulLogin_ValidatesPageTitle(string browser, string username, string password)
        {
            Logger.Info($"Starting Test UC2 on {browser} and navegating to the Web");
            IWebDriver driver = DriverFactory.InitializeDriver(browser);
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();

            Logger.Info("Entering username and password");
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);

            Logger.Info("Clicking login button");
            loginPage.ClickLogin();
            Logger.Info("Validating successful login by navigating to the invetory page");

            Logger.Info("Validating the inventory page title");
            inventoryPage.GetPageTitle().Should().Be("Swag Labs");

            Logger.Info("Test finished successfully");
            driver.Quit();
        }
    }
}
