using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace SauceDemoAutomation.Core
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            IWebDriver driver;
            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser type: {browser}");
            }
            return driver;
        }
    }
}
