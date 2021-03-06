using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Testing.Web.Config;

namespace Testing.Web.Core
{
    public class BrowserManager
    {
        private IWebDriver _driver { get; set; }
        private string _driverPath { get; set; }
        
        public BrowserManager(string driverPath)
        {
            _driverPath = driverPath;
        }

        public IWebDriver CreateDriver()
        {
            if (!string.IsNullOrEmpty(TestConfig.BrowserName) && !string.IsNullOrEmpty(_driverPath))
            {
                switch(TestConfig.BrowserName)
                {
                    case "chrome":  SetChrome();  break;
                    case "firefox": SetFirefox(); break;
                    default: break;
                }
            }
            return _driver;
        }

        private void SetChrome()
        {
            var options = new ChromeOptions() {
                    AcceptInsecureCertificates = true,
                    PageLoadStrategy = PageLoadStrategy.Default
                };
            if (TestConfig.RunHeadless) 
                options.AddArgument("--headless");
            if (TestConfig.UseRemoteHost)
                _driver = new RemoteWebDriver(new Uri(TestConfig.SeleniumAddress), options);
            else
                _driver = new ChromeDriver(_driverPath, options);
        }

        private void SetFirefox()
        {
            var options = new FirefoxOptions();
            if (TestConfig.UseRemoteHost)
                _driver = new RemoteWebDriver(new Uri(TestConfig.SeleniumAddress), options);
            else
                _driver = new FirefoxDriver(_driverPath, options);
        }
    }
}