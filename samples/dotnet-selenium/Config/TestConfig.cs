namespace Testing.Web.Config
{
    public class TestConfig
    {
        public static string BaseUrl { get; set; }
        public static string Environment { get; set; }
        public static string BrowserName { get; set; }
        public static string TestUsername { get; set; }
        public static string TestPassword { get; set; }
        public static string SeleniumAddress { get; set; }
        public static bool RunHeadless { get; set; }
        public static int ImplicitWaitTimeout { get; set; }
        public static int WebDriverWaitTimeout { get; set; }
        public static bool UseRemoteHost { get; set; }
    }
}