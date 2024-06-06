
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumMyStoreWebAppTest.Util;

public static class Reporter{

    private static ExtentReports _extentReports=new();


    public static void AttachReporter(string fileName){
            var currentDirectory = Environment.CurrentDirectory;
            var projectRootDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName??"";
            var reportDirectory = Path.Combine(projectRootDirectory,"Report");
            var reporter = new ExtentSparkReporter(Path.Combine(reportDirectory, fileName));
            _extentReports.AttachReporter(reporter);
    }

    public static void FlushReporters(){
        _extentReports.Flush();
    }

    public static ExtentReports Extent =>_extentReports;
}