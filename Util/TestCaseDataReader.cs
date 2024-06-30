using System.Text.Json;

namespace SeleniumMyStoreWebAppFramework.Util;

public class TestCaseDataReader
{
    static public List<T>? ReadJsonDataListForTestCases<T>(string jsonFileName)
    {
        var currentDirectory = Environment.CurrentDirectory;
        var testCaseDataDir = Path.Combine(currentDirectory, "TestCaseData");
        var jsonFilePath = Path.Combine(testCaseDataDir, jsonFileName);
        try
        {
            var jsonString = File.ReadAllText(jsonFilePath);
            var testCaseDataList = JsonSerializer.Deserialize<List<T>>(jsonString);
            return testCaseDataList;
        }
        catch (FileNotFoundException e)
        {
            Console.Error.WriteLine($"Json file not found at the following path: {jsonFilePath} ");
            Console.Error.WriteLine(e.ToString());
            throw;
        }
    }
}