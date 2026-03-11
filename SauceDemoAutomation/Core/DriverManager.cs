using OpenQA.Selenium;

namespace SauceDemoAutomation.Core
{
    public sealed class DriverManager
    {
        private static IWebDriver? fieldDriver;

        private DriverManager() 
        { 
        }

        public static IWebDriver Driver
        { 
            get 
            { 
                if (fieldDriver == null)
                {
                    throw new InvalidOperationException("WebDriver has not been initialized. Please call SetDriver() before accessing the Driver property.");
                }
                return fieldDriver; 
            }
        }

        public static void SetDriver(IWebDriver driver)
        {
            fieldDriver = driver;
        }

        public static void QuitDriver()
        {

            fieldDriver?.Quit();
            fieldDriver = null;

        }

    }
}
