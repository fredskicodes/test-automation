using System;
using NUnit.Framework;
using OpenQA.Selenium;
using static Testing.Foo.Core.DriverFactory;

namespace Testing.Foo.Tests.Web
{
    [SetUpFixture]
    public class TestFixtureSetup
    {
        private IWebDriver _driver;
        
        [OneTimeSetUp]
        public void OnSetup()
        {
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