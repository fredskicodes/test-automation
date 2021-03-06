
using NUnit.Framework;
using OpenQA.Selenium;
using Testing.Web.Config;
using static Testing.Web.Core.DriverFactory;

namespace Testing.Web.Tests
{
    [SetUpFixture]
    public class TestFixtureSetup
    {
        private IWebDriver _driver;
        
        [OneTimeSetUp]
        public void OnSetup()
        {
            Configuration.Initialize(new TestConfig());
            _driver = GetWebDriver();
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void OnTearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}