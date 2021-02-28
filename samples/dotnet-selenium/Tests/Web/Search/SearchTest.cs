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
            extentTest = extentReport.CreateTest(TestContext.CurrentContext.Test.Properties.Get("Description").ToString());
        }

        [TearDown]
        public void TearDown()
        {
            LogTestResult();
        }

        [Test]
        [Description("Search - Can Search by specific keyword.")]
        public void Search_CanSearchkeyword()
        {
            _search.DoSearch("selenium");
            _search.Verify.BodyTextContains("SeleniumHQ Browser Automation");
        }

        [Test]
        [Description("Search - Fail test on purpose.")]
        public void FailForFun()
        {
            Assert.Fail();
        }
    }
}