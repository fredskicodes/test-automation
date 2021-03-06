using FluentAssertions;
using OpenQA.Selenium;

namespace Testing.Web.Pages.Search
{
    public class SearchVerify
    {
        private IWebDriver _driver { get; }

        public SearchVerify(IWebDriver driver)
        {
            _driver = driver;
        }

        public void BodyTextContains(string text)
        {
            var source = _driver.FindElement(By.TagName("body")).Text;
            source.Should().Contain(text);
        }
    }
}