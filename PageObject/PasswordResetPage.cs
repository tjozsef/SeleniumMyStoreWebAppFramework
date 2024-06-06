using OpenQA.Selenium;
using SeleniumMyStoreWebAppTest.Util;

namespace SeleniumMyStoreWebAppTest.PageObject;

public class PasswordResetPage(IWebDriver driver) : BasePageObject(driver)
{

    private IWebElement EmailField => _driver.FindElement(By.Id("email"));
    private IWebElement BackToLoginLink => _driver.FindElement(By.CssSelector("#back-to-login > span"));
    private IWebElement SendResetLinkButton => _driver.FindElement(By.Id("send-reset-link"));
    private IWebElement SuccessResetIcon => _driver.FindElement(By.CssSelector("svg"));
    public void GoToPasswordResetPage()
    {
        _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk/index.php?controller=password");
    }

    public void EnterEmail(string email)
    {
        EmailField.Clicks();
        EmailField.EnterText(email);
    }

    public void ClickBackToLoginLink()
    {
        BackToLoginLink.Clicks();
    }

    public void ClickSendResetLinkButton()
    {
        SendResetLinkButton.Click();
    }

    public bool IsSuccessfullPasswordReset()
    {
        try
        {
            return SuccessResetIcon.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

}
