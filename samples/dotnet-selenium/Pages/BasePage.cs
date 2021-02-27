using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using Testing.Foo.Config;
using static Testing.Foo.Core.DriverFactory;

namespace Testing.Foo.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver = GetWebDriver();
        protected IConfiguration config = Configuration.GetConfiguration();

        public void GoTo()
        {
            driver.Navigate().GoToUrl(config["baseUrl"]);
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