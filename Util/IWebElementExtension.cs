using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumMyStoreWebAppTest.Util;

public static class IWebElementExtension
{

    public static void Clicks(this IWebElement locator)
    {
        locator.Click();
    }

    public static void Submits(this IWebElement locator)
    {
        locator.Submit();
    }

    public static void EnterText(this IWebElement locator, string text)
    {
        locator.Clear();
        locator.SendKeys(text);
    }

    public static void SelectDropDownByText(this IWebElement locator, string text)
    {
        var selectElement = new SelectElement(locator);
        selectElement.SelectByText(text);
    }

    public static void SelectDropDownByValue(this IWebElement locator, string value)
    {
        var selectElement = new SelectElement(locator);
        selectElement.SelectByValue(value);
    }

    public static void SelectMultipleDropDownElementsByText(this IWebElement locator, string[] texts)
    {
        var selectElement = new SelectElement(locator);
        foreach (var text in texts)
        {
            selectElement.SelectByText(text);
        }
    }


    public static void SelectMultipleDropDownElementsByValue(this IWebElement locator, string[] values)
    {
        var selectElement = new SelectElement(locator);
        foreach (var value in values)
        {
            selectElement.SelectByValue(value);
        }
    }

    public static List<string> GetAllSelectedDropDownTexts(this IWebElement locator)
    {
        var selectedTexts = new List<string>();
        var selectElement = new SelectElement(locator);

        var allSelectedOptions = selectElement.AllSelectedOptions;
        foreach (IWebElement selectedOption in allSelectedOptions)
        {
            selectedTexts.Add(selectedOption.Text);
        }
        return selectedTexts;
    }

}