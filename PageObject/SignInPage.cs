using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppTest.PageObject;

public class SignInPage(IWebDriver driver) : BasePageObject(driver)
{
    private IWebElement Email => _driver.FindElement(By.Id("field-email"));
    private IWebElement Password => _driver.FindElement(By.Id("field-password"));
    private IWebElement ShowPasswordButton => _driver.FindElement(By.CssSelector(".input-group-btn > .btn"));
    private IWebElement ForgotPasswordLink => _driver.FindElement(By.LinkText("Forgot your password?"));
    private IWebElement SignInButton => _driver.FindElement(By.CssSelector("button#submit-login"));

    public void GoToPageSignInPage()
    {
        _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk/index.php?controller=authentication");
    }

    public void EnterEmail(string email)
    {
        Email.Click();
        Email.SendKeys(email);
    }

    public void EnterPassword(string password)
    {
        Password.Click();
        Password.SendKeys(password);
    }

    public void ClickSignInButton()
    {
        SignInButton.Click();
    }

    public void ClickShowPasswordButton()
    {
        ShowPasswordButton.Click();
    }

    public void ClickForgotPasswordLink()
    {
        ForgotPasswordLink.Click();
    }

    public bool IsSignedOut()
    {
        try
        {
            return ForgotPasswordLink.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
