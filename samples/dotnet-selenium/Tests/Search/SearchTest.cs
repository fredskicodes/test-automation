using NUnit.Framework;
using Testing.Web.Pages.Search;

namespace Testing.Web.Tests.Search
{
    public class SearchTest : BaseTest
    {
        private SearchPage _search = new SearchPage();

        [SetUp]
        public void BeforeTest()
        {
            _search.GoTo();
            extentTest = extentReport.CreateTest(TestContext.CurrentContext.Test.Properties.Get("Description").ToString());
        }

        [TearDown]
        public void AfterTest()
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
    }
}