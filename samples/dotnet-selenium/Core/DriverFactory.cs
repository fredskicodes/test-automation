using Testing.Foo.Config;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Testing.Foo.Core 
{
    public class DriverFactory
    {
        private static IWebDriver _driver { get; set; }
        private static IConfiguration _config = Configuration.GetConfiguration();
        
        public static IWebDriver GetWebDriver()
        {
            if (_driver == null)
            {
                var driverManager = new BrowserManager(_config["browserName"], Directory.GetCurrentDirectory());
                _driver = driverManager.CreateDriver();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(_config["implicitWaitTimeout"]));
            }
            return _driver;
        }   
    }
}