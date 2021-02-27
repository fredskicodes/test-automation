using OpenQA.Selenium;

namespace Testing.Foo.Pages.Search
{
    public class SearchPage : BasePage
    {
        private By _searchField = By.Name("q");
        public SearchVerify Verify { get; }
        
        public SearchPage()
        {
            Verify = new SearchVerify(driver);
        }
        
        public void DoSearch(string query)
        {
            SetInput(_searchField, query).Submit();
        }
    }
}