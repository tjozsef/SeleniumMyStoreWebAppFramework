using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumMyStoreWebAppTest.PageObject;

public abstract class BasePageObject(IWebDriver driver)
{
    protected IWebDriver _driver = driver;
    private IJavaScriptExecutor _jsExecutor => (IJavaScriptExecutor)_driver;


    protected void GoToUrl(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }
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

    protected void ScrollToWebElement(IWebElement element)
    {
        _jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    protected void ScrollAndHoverMouseOverWebElement(IWebElement element)
    {
        ScrollToWebElement(element);
        var action = new Actions(_driver);
        action.MoveToElement(element).Perform();
    }

    protected void WaitUntilElementIsClickAble(IWebElement element, int waitSeconds = 4)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitSeconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    protected void WaitUntilElementIsVisible(By selector, int waitSeconds = 4)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitSeconds));
        wait.Until(ExpectedConditions.ElementIsVisible(selector));
    }

}