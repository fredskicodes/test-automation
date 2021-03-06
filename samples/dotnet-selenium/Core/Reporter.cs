using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Testing.Web.Core
{
    public abstract class Reporter
    {
        protected ExtentReports extentReport = null;
        protected ExtentHtmlReporter htmlReporter = null;
        protected ExtentTest extentTest;

        [OneTimeSetUp]
        public void OnSetup()
        {
            var dir = TestContext.CurrentContext.TestDirectory;
            var filename = "TestResults.html";

            if (extentReport == null)
            {
                htmlReporter = new ExtentHtmlReporter($"{dir}{filename}");
                htmlReporter.Config.DocumentTitle = "Tests Report";
                htmlReporter.Config.ReportName = "Regression Tests Suite";
                extentReport = new ExtentReports();
                extentReport.AttachReporter(htmlReporter);
            }
        }

        [OneTimeTearDown]
        public void OnTearDown()
        {
            extentReport.Flush();
        }

        public void LogTestResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : $"{TestContext.CurrentContext.Result.StackTrace}";
            
            Status logstatus;
            
            var outcome = TestContext.CurrentContext.Result.Outcome;
            
            switch(status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            
            extentTest.Log(logstatus, $"Test ended with {logstatus} {stackTrace}");
            extentReport.Flush();
        }
    }
}
