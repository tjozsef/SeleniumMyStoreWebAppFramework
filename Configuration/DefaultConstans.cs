namespace SeleniumMyStoreWebAppFramework.Configuration
{

    static class DefaultConstans
    {
        public static string FallBackBrowser => "Chrome";
        public static string BrowserKey => "browserName";

        public static int ImplicitWaitSeconds => 1;

        public const int LevelOfParallelism = 2;
    }
}