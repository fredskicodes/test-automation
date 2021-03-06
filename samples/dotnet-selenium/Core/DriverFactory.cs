using Testing.Web.Config;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Testing.Web.Core
{
    public class DriverFactory
    {
        private static IWebDriver _driver { get; set; }
        
        public static IWebDriver GetWebDriver()
        {
            if (_driver == null)
            {
                var driverPath = Directory.GetCurrentDirectory();
                var driverManager = new BrowserManager(driverPath);
                _driver = driverManager.CreateDriver();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TestConfig.ImplicitWaitTimeout);
            }
            return _driver;
        }   
    }
}