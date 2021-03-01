using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Testing.Foo.Core
{
    public class BrowserManager
    {
        private IWebDriver _driver { get; set; }
        private IConfiguration _config { get; }
        
        public BrowserManager(IConfiguration config)
        {
            _config = config;
        }

        public IWebDriver CreateDriver()
        {
            var browserName = _config["browserName"];
            var driverPath = Directory.GetCurrentDirectory();
            var runHeadless = bool.Parse(_config["runHeadless"]);
            var useRemoteHost = bool.Parse(_config["useRemoteHost"]);
            
            if (!string.IsNullOrEmpty(browserName) && !string.IsNullOrEmpty(driverPath))
            {
                switch(browserName)
                {
                    case "chrome":  SetChrome(driverPath, runHeadless, useRemoteHost);  break;
                    case "firefox": SetFirefox(driverPath, useRemoteHost); break;
                    default: break;
                }
            }
            return _driver;
        }

        private void SetChrome(string driverPath, bool runHeadless, bool useRemoteHost)
        {
            var options = new ChromeOptions() {
                    AcceptInsecureCertificates = true,
                    PageLoadStrategy = PageLoadStrategy.Default
                };
            if (runHeadless) 
                options.AddArgument("--headless");
            if (useRemoteHost)
                _driver = new RemoteWebDriver(new Uri(_config["seleniumAddress"]), options);
            else
                _driver = new ChromeDriver(driverPath, options);
        }

        private void SetFirefox(string driverPath, bool useRemoteHost)
        {
            var options = new FirefoxOptions();
            if (useRemoteHost)
                _driver = new RemoteWebDriver(new Uri(_config["seleniumAddress"]), options);
            else
                _driver = new FirefoxDriver(driverPath, options);
        }
    }
}