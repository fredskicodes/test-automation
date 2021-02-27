using NUnit.Framework;
using Testing.Foo.Pages.Search;

namespace Testing.Foo.Tests.Web.Search
{
    public class SearchTest : BaseTest
    {
        private SearchPage _search = new SearchPage();

        [SetUp]
        public void Setup()
        {
            _search.GoTo();
            extentTest = extentReport.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            LogTestResult();
        }

        [Test]
        public void Search_CanSearchkeyword()
        {
            _search.DoSearch("selenium");
            _search.Verify.BodyTextContains("SeleniumHQ Browser Automation");
        }

        [Test]
        public void FailForFun()
        {
            Assert.Fail();
        }
    }
}