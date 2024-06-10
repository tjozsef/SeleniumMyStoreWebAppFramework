
using SeleniumMyStoreWebAppTest.DataModel;
using SeleniumMyStoreWebAppTest.PageObject;

namespace SeleniumMyStoreWebAppTest.Auth
{
    public class SignInPositive : BaseTest
    {
        private SignInPage _signInPage;
        [SetUp]
        public void SetupPage()
        {
            _signInPage = new SignInPage(_driver);
            _signInPage.GoToPageSignInPage();
        }

        [Test, Description("Sign in with valid credentials.")]
        [Category("smoke")]
        [TestCaseSource(nameof(GetValidSignInCredentials))]
        public void SignIn(AuthCredential credential)
        {
            Assert.That(_signInPage.IsSignedOut(), "Excpected precondition User is signed out!");
            _testCaseLogEntry.Pass("User is signed out." + new Random().NextInt64());
            _signInPage.EnterEmail(credential.Emailaddress);
            _signInPage.EnterPassword(credential.Password);
            _signInPage.ClickShowPasswordButton();
            var homePage = _signInPage.ClickSignInButton();
            Assert.That(homePage.IsSignedIn(), "User is not signed in!");
        }

        private static IEnumerable<AuthCredential> GetValidSignInCredentials()
        {
            var authCredentialList = new List<AuthCredential> {
             new()
            {
                Emailaddress = "testusermail@test.com",
                Password = "ThisIsAStrongPassword123",
            },
             new()
            {
                Emailaddress = "testadmin@test.com",
                Password = "ThisIsAStrongPassword123",
            }
        };
            return authCredentialList.AsEnumerable();
        }
    }
}