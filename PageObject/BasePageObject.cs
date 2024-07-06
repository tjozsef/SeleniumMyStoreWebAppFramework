using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumMyStoreWebAppFramework.PageObject;

public abstract class BasePageObject(IWebDriver driver)
{
    protected IWebDriver _driver = driver;
    private IJavaScriptExecutor _jsExecutor => (IJavaScriptExecutor)_driver;
    protected static By CssSelector(string cssSelectorToFind) => By.CssSelector(cssSelectorToFind);

    protected static By Name(string nameToFind) => By.Name(nameToFind);

    protected static By XPath(string xpathToFind) => By.XPath(xpathToFind);

    protected IWebElement FindElement(By selector) => _driver.FindElement(selector);
    protected IWebElement ActiveElement() => _driver.SwitchTo().ActiveElement();
    protected ReadOnlyCollection<IWebElement> FindElements(By selector) => _driver.FindElements(selector);
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

    protected int GetCountOnElementWithWaitUntilVisible(By selector)
    {
        var element = WaitUntilElementIsVisible(selector);
        return GetCountOnElement(element);
    }
    protected int GetCountOnElement(IWebElement element) => (int)GetNumberOnElement(element);

    protected double GetNumberOnElement(IWebElement element)
    {
        var numberStr = element.Text;
        double number;
        if (numberStr == "")
        {
            numberStr = element.GetDomProperty("value");
            if (numberStr == null) throw new Exception($"Could not determine the number value on the webelement: {element.TagName}");
        }
        numberStr = numberStr.Replace("$", "").Replace("€", "");
        number = Convert.ToDouble(numberStr);
        return number;
    }

    protected void ScrollToWebElement(IWebElement element)
    {
        _jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    public bool IsImageDisplayed(IWebElement imageElement)
    {
        var resultObject = _jsExecutor.ExecuteScript("return arguments[0].complete " + "&& typeof arguments[0].naturalWidth != \"undefined\" " + "&& arguments[0].naturalWidth > 0", imageElement);
        return true;
    }

    protected void ScrollAndHoverMouseOverWebElement(IWebElement element)
    {
        ScrollToWebElement(element);
        var action = new Actions(_driver);
        action.MoveToElement(element).Perform();
    }

    protected void WaitUntilElementIsClickAble(IWebElement element, int waitSeconds = 5)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitSeconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    protected IWebElement WaitUntilElementIsVisible(By selector, int waitSeconds = 5)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitSeconds));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(selector));
        return element;
    }

    public IWebElement? FindSubElementOrNullQuickly(IWebElement mainElement, By subElementSelector)
    {
        try
        {
            return mainElement.FindElement(subElementSelector);
        }
        catch (NoSuchElementException)
        {
            return null;
        }
    }

}