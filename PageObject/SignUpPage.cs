using OpenQA.Selenium;


namespace SeleniumMyStoreWebAppTest.PageObject;
public class SignUpPage(IWebDriver driver) : BasePageObject(driver)
{
    private IWebElement GenderMaleRadioButton => _driver.FindElement(By.Id("field-id_gender-1"));
    private IWebElement GenderFemaleRadioButton => _driver.FindElement(By.Id("field-id_gender-2"));
    private IWebElement FirstNameField => _driver.FindElement(By.Id("field-firstname"));
    private IWebElement LastNameField => _driver.FindElement(By.Id("field-lastname"));
    private IWebElement EmailField => _driver.FindElement(By.Id("field-email"));
    private IWebElement PasswordField => _driver.FindElement(By.Id("field-password"));
    private IWebElement BirthdayField => _driver.FindElement(By.Id("field-birthday"));
    private IWebElement SubmitButton => _driver.FindElement(By.CssSelector(".input-group-btn > .btn"));
    private IWebElement ReceiveOffersCheckbox => _driver.FindElement(By.Name("optin"));
    private IWebElement AcceptTermsAndPolicyCheckbox => _driver.FindElement(By.Name("psgdpr"));
    private IWebElement ReceiveNewsletterCheckbox => _driver.FindElement(By.Name("newsletter"));
    private IWebElement SubmitFormButton => _driver.FindElement(By.CssSelector(".form-control-submit"));
    private By LogInInsteadLink => By.CssSelector("div#content a");
    private By EmailAddressUsedAlertText => By.CssSelector("ul > .alert.alert-danger");

    // Page actions
    public void GoToPageSignUpPage()
    {
        _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk/index.php?controller=registration");
    }

    public void SetGenderMale()
    {
        GenderMaleRadioButton.Click();
    }

    public void SetGenderFemale()
    {
        GenderFemaleRadioButton.Click();
    }

    public void EnterFirstName(string firstName)
    {
        FirstNameField.Click();
        FirstNameField.SendKeys(firstName);
    }

    public void EnterLastName(string lastName)
    {
        LastNameField.Click();
        LastNameField.SendKeys(lastName);
    }

    public void EnterEmail(string email)
    {
        EmailField.Click();
        EmailField.SendKeys(email);
    }

    public void EnterUniqueEmail()
    {
        EmailField.Click();
        EmailField.SendKeys($"testuseremail{Guid.NewGuid()}@test.com");
    }

    public void EnterPassword(string password)
    {
        PasswordField.Click();
        PasswordField.SendKeys(password);
    }

    public void EnterBirthday(string birthday)
    {
        BirthdayField.Click();
        BirthdayField.SendKeys(birthday);
    }

    public void ClickSubmitButton()
    {
        SubmitButton.Click();
    }

    public void ClickReceiveOffersCheckbox()
    {
        ReceiveOffersCheckbox.Click();
    }

    public void ClickAcceptTermsAndPolicyCheckbox()
    {
        AcceptTermsAndPolicyCheckbox.Click();
    }

    public void ClickReceiveNewsletterCheckbox()
    {
        ReceiveNewsletterCheckbox.Click();
    }

    public void ClickSubmitFormButton()
    {
        SubmitFormButton.Click();
    }
    public bool IsSignedOut() => IsElementDisplayed(LogInInsteadLink);
    public bool IsEmailUniqe() => !IsElementDisplayed(EmailAddressUsedAlertText);

    //public bool IsInvalidEmail()=>IsPromptAlertPresent(); 
    //TODO:HTML5 field validation tooltip can not be located if developer used default messages

}
