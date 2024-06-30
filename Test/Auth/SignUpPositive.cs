using SeleniumMyStoreWebAppFramework.DataModel;
using SeleniumMyStoreWebAppFramework.PageObject;
using SeleniumMyStoreWebAppFramework.Util;
namespace SeleniumMyStoreWebAppFramework.Test.Auth
{
    [TestFixture]
    public class SignUpPositive : BaseTest
    {
        private SignUpPage _signUpPage;
        [SetUp]
        public void SetupPage()
        {
            _signUpPage = new SignUpPage(_driver);
            _signUpPage.GoToPageSignUpPage();
        }


        [TestCaseSource(nameof(GetRFCComplaintEmailAdressesWithPassword))]
        public void SignUpRFCEmailAddress(AuthCredential authCredential)
        {

            Assert.That(_signUpPage.IsSignedOut, "Expected precondition User is signed out!");
            _signUpPage.SetGenderFemale();
            _signUpPage.EnterFirstName("TestUserFirstName");
            _signUpPage.EnterLastName("TestUserLastName");
            var uniqueEmail = Guid + authCredential.Emailaddress;
            _signUpPage.EnterEmail(uniqueEmail);
            _signUpPage.EnterPassword(authCredential.Password);
            _signUpPage.ClickAcceptTermsAndPolicyCheckbox();
            var homePage = _signUpPage.ClickSubmitFormButton();
            Assert.That(homePage.IsUserSignedIn(), "Expected postcondition User is signed in!");
        }


        [Test]
        [Category("smoke")]
        public void SignUpWithmandatoryFields()
        {
            Assert.That(_signUpPage.IsSignedOut, "Expected precondition User is signed out!");
            _signUpPage.SetGenderFemale();
            _signUpPage.EnterFirstName(TestDataConstants.TestUserFirstName);
            _signUpPage.EnterLastName(TestDataConstants.TestUserLastName);
            _signUpPage.EnterUniqueEmail();
            _signUpPage.EnterPassword(TestDataConstants.StrongPassword);
            _signUpPage.ClickAcceptTermsAndPolicyCheckbox();
            var homePage = _signUpPage.ClickSubmitFormButton();
            Assert.That(homePage.IsUserSignedIn(), "Expected postcondition User is signed in!");
        }
        [Test]
        [Category("smoke")]
        public void SignUpWithOptinalFields()
        {
            Assert.That(_signUpPage.IsSignedOut, "User is already signed in!");
            _signUpPage.SetGenderMale();
            _signUpPage.EnterFirstName(TestDataConstants.TestUserFirstName);
            _signUpPage.EnterLastName(TestDataConstants.TestUserLastName);
            _signUpPage.EnterUniqueEmail();
            _signUpPage.EnterPassword(TestDataConstants.StrongPassword);
            _signUpPage.ClickAcceptTermsAndPolicyCheckbox();
            _signUpPage.ClickReceiveNewsletterCheckbox();
            _signUpPage.ClickReceiveOffersCheckbox();
            var homePage = _signUpPage.ClickSubmitFormButton();
            Assert.That(homePage.IsUserSignedIn(), "Expected postcondition User is signed in!");
        }



        private static IEnumerable<AuthCredential>? GetRFCComplaintEmailAdressesWithPassword()
        {
            var authCredentialList = TestCaseDataReader.ReadJsonDataListForTestCases<AuthCredential>(TestDataConstants.RFCValidEmailAdressesFileName);
            return authCredentialList?.AsEnumerable();
        }
    }
}