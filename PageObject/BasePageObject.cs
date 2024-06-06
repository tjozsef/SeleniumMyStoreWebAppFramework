using System.Runtime.InteropServices.JavaScript;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumMyStoreWebAppTest.PageObject;

public abstract class BasePageObject(IWebDriver driver)
{
    protected IWebDriver _driver = driver;
    protected bool IsElementDisplayed(By locator)
    {
        try
        {
            var element = _driver.FindElement(locator);
            return element.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    protected bool IsAlertPresent()
    {
        try
        {
            var alertText = _driver.SwitchTo().Alert().Text;
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }
}