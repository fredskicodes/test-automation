using OpenQA.Selenium;
using System;
using System.Threading;
using static Testing.Foo.Core.DriverFactory;

namespace Testing.Foo.Core
{
    public class TestHelper
    {
        private static IWebDriver _driver = GetWebDriver();
        
        public static void RunScript(string script, IWebElement element = null)
        {
            var jsExecutor = (IJavaScriptExecutor) _driver; 
            jsExecutor.ExecuteScript(script, element);
        }

        public static void Wait(int seconds = 1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        public static string TaekScreenShotAsBase64()
        {
            var capture = (ITakesScreenshot) _driver;
            return capture.GetScreenshot().AsBase64EncodedString;
        }
    }
}