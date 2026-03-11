using OpenQA.Selenium;

namespace SauceDemoAutomation.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly By pageTitle = By.XPath("//div[@class='app_logo']");

        public string GetPageTitle()
        {
            return Driver.FindElement(pageTitle).Text;
        }
    }
}
