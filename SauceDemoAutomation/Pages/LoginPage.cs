using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoAutomation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameField = By.XPath("//input[@id='user-name']");
        private readonly By passwordField = By.XPath("//input[@id='password']");
        private readonly By loginButton = By.XPath("//input[@id='login-button']");
        private readonly By errorMessage = By.XPath("//h3[@data-test='error']");

        public void EnterUsername(string username)
        {
            Driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClearUsername()
        {
            var element = Driver.FindElement(usernameField);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        public void ClearPassword()
        {
            var element = Driver.FindElement(passwordField);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        public void ClickLogin()
        { 
            Driver.FindElement(loginButton).Click();
        }

        public string GetErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            
            var errorElement = wait.Until(driver => driver.FindElement(errorMessage));

            return errorElement.Text;
        }
    }
}
