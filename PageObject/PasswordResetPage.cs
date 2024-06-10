using OpenQA.Selenium;
using SeleniumMyStoreWebAppTest.Util;

namespace SeleniumMyStoreWebAppTest.PageObject;

public class PasswordResetPage(IWebDriver driver) : BasePageObject(driver)
{
    private const string _passwordResetPageUrl = "https://teststore.automationtesting.co.uk/index.php?controller=password";

    #region Selector Queries
    private By _emailFieldQ = By.Id("email");
    private By _backToLoginLinkQ = By.CssSelector("#back-to-login > span");
    private By _sendResetLinkButtonQ = By.Id("send-reset-link");
    private By _successResetIconQ = By.CssSelector("svg");

    private IWebElement _emailField => _driver.FindElement(_emailFieldQ);
    private IWebElement _backToLoginLink => _driver.FindElement(_backToLoginLinkQ);
    private IWebElement _sendResetLinkButton => _driver.FindElement(_sendResetLinkButtonQ);
    private IWebElement _successResetIcon => _driver.FindElement(_successResetIconQ);
    #endregion
    public void GoToPasswordResetPage() => GoToUrl(_passwordResetPageUrl);


    public void EnterEmail(string email)
    {
        _emailField.Clicks();
        _emailField.EnterText(email);
    }

    public void ClickBackToLoginLink()
    {
        _backToLoginLink.Clicks();
    }

    public void ClickSendResetLinkButton()
    {
        _sendResetLinkButton.Click();
    }

    public bool IsSuccessfullPasswordReset()
    {
        try
        {
            return _successResetIcon.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

}
