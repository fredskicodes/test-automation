using OpenQA.Selenium;
using Testing.Web.Config;
using static Testing.Web.Core.DriverFactory;

namespace Testing.Web.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver = GetWebDriver();

        public void GoTo()
        {
            driver.Navigate().GoToUrl(TestConfig.BaseUrl);
        }

        public IWebElement SetInput(By locator, string value)
        {
            var element = driver.FindElement(locator);
            element.Clear();
            element.SendKeys(value);
            return element;
        }
    }
}