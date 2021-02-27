using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Testing.Foo.Core
{
    public class BrowserManager
    {
        private IWebDriver _driver { get; set; }
        private string _browserName { get; set; }
        private string _driverPath { get; set; }
        private bool _runHeadless { get; set; }
        
        public BrowserManager(string browserName, string driverPath, bool runHeadless = false)
        {
            _browserName = browserName;
            _driverPath = driverPath;
            _runHeadless = runHeadless;
        }

        public IWebDriver CreateDriver()
        {
            if (!string.IsNullOrEmpty(_browserName) && !string.IsNullOrEmpty(_driverPath))
            {
                switch(_browserName)
                {
                    case "chrome":  SetChrome();  break;
                    case "firefox": SetFirefox(); break;
                    default: break;
                }
            }
            return _driver;
        }

        public void SetChrome()
        {
            var options = new ChromeOptions() {
                    AcceptInsecureCertificates = true,
                    PageLoadStrategy = PageLoadStrategy.Default
                };
            if (_runHeadless)
            options.AddArgument("--headless");
            _driver = new ChromeDriver(_driverPath, options);
        }

        public void SetFirefox()
        {
            var options = new FirefoxOptions();
            _driver = new FirefoxDriver(_driverPath, options);
        }
    }
}