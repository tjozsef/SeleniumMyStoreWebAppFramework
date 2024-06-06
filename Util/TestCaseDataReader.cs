
using System.Text.Json;

namespace SeleniumMyStoreWebAppTest.Util;

public class TestCaseDataReader
{
    static public List<T> ReadJsonDataListForTestCases<T>(string jsonFileName)
    {
        try
        {
            var currentDirectory = Environment.CurrentDirectory;
            var projectRootDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName??"";
            var testCaseDataDir = Path.Combine(projectRootDirectory,"TestCaseData");
            var jsonFilePath = Path.Combine(testCaseDataDir,jsonFileName);
            var jsonString = File.ReadAllText(jsonFileName);
            var testCaseDataList = JsonSerializer.Deserialize<List<T>>(jsonString)??[];
            return testCaseDataList;
        }
        catch (FileNotFoundException e)
        {
            Console.Error.WriteLine("Json file not found at path: {path} ");
            Console.Error.WriteLine(e.ToString());
            return [];
        }
        catch (JsonException e)
        {
            Console.Error.WriteLine("Invalid json format!");
            Console.Error.WriteLine(e.ToString());
            return [];
        }
    }
}