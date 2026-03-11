using OpenQA.Selenium;
using SauceDemoAutomation.Core;

namespace SauceDemoAutomation.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver => DriverManager.Driver;
    }
}