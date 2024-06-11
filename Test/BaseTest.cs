
using System.Globalization;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumMyStoreWebAppTest.Util;

namespace SeleniumMyStoreWebAppTest;


[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest
{

    protected static Guid Guid => Guid.NewGuid();
    protected IWebDriver _driver;
    protected ExtentTest _testCaseLogEntry;

    [OneTimeSetUp]
    public static void SetupReporter()
    {
        Reporter.AttachReporter("index.html");
    }


    [OneTimeTearDown]
    public static void FlushReporters()
    {
        Reporter.FlushReporters();
    }

    [SetUp]
    public void SetupCultureSettings()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
    }

    [SetUp]
    public void SetupDriver()
    {
        _driver = DriverFactory.GetWebDriver();
    }

    [TearDown]
    public void TearDownDriver()
    {
        DriverFactory.TearDownWebDriver();
    }

    [SetUp]
    public void CreateTestCaseLogEntry()
    {
        var testName = TestContext.CurrentContext.Test.MethodName;
        _testCaseLogEntry = Reporter.Extent.CreateTest(testName).Log(Status.Pass, "This is a dummy log text!");

    }

    [TearDown]
    public void CloseTestCaseLogEntry()
    {
    }


}