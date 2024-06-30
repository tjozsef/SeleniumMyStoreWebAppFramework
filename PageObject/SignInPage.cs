using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppTest.PageObject;

public class SignInPage(IWebDriver driver) : BasePageObject(driver)
{
    private const string _signInPageUrl = "https://teststore.automationtesting.co.uk/index.php?controller=authentication";
    #region Selector Queries
    private By _emailFieldQ = By.Id("field-email");
    private By _passwordFieldQ = By.Id("field-password");
    private By _showPasswordButtonQ = By.CssSelector(".input-group-btn > .btn");
    private By _forgotPasswordLinkQ = By.LinkText("Forgot your password?");
    private By _signInButtonQ = By.CssSelector("button#submit-login");

    private IWebElement _emailField => _driver.FindElement(_emailFieldQ);
    private IWebElement _passwordField => _driver.FindElement(_passwordFieldQ);
    private IWebElement _showPasswordButton => _driver.FindElement(_showPasswordButtonQ);
    private IWebElement _forgotPasswordLink => _driver.FindElement(_forgotPasswordLinkQ);
    private IWebElement _signInButton => _driver.FindElement(_signInButtonQ);
    #endregion
    public void GoToSignInPage() => GoToUrl(_signInPageUrl);


    public void EnterEmail(string email)
    {
        _emailField.Click();
        _emailField.SendKeys(email);
    }

    public void EnterPassword(string password)
    {
        _passwordField.Click();
        _passwordField.SendKeys(password);
    }

    public HomePage ClickSignInButton()
    {
        _signInButton.Click();
        return new HomePage(_driver);
    }

    public void ClickShowPasswordButton()
    {
        _showPasswordButton.Click();
    }

    public void ClickForgotPasswordLink()
    {
        _forgotPasswordLink.Click();
    }

    public bool IsSignedOut()
    {
        try
        {
            return _forgotPasswordLink.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
