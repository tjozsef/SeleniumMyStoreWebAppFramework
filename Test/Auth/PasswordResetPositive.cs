using SeleniumMyStoreWebAppTest.PageObject;
using CategoryAttribute = NUnit.Framework.CategoryAttribute;

namespace SeleniumMyStoreWebAppTest.Auth;
public class PasswordResetPositive : BaseTest
{
    private PasswordResetPage _passwordResetPage;
    [SetUp]
    public void SetupPage()
    {
        _passwordResetPage = new PasswordResetPage(_driver);
        _passwordResetPage.GoToPasswordResetPage();
    }

    [Test, Description("Reset email with valid email address")]
    [Category("smoke")]
    public void ResetPasswordWithEmail()
    {
        Assert.That(_driver.Title, Is.EqualTo("Forgot your password"));
        _passwordResetPage.EnterEmail("testuseremail@test.com");
        _passwordResetPage.ClickSendResetLinkButton();
        Assert.That(_passwordResetPage.IsSuccessfullPasswordReset(), "Password reset has failed!");
    }

}