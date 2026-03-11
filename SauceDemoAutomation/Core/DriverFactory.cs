using OpenQA.Selenium;

namespace SauceDemoAutomation.Core
{
    public static class DriverFactory
    {
        public static IWebDriver InitializeDriver(string browser)
        {
            IWebDriver driver = BrowserFactory.CreateDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            DriverManager.SetDriver(driver);

            return driver;
        }
    }
}
