using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppFramework.PageObject;

class ProductSuccessfullyAddedModal(IWebDriver driver) : BasePageObject(driver)
{

    #region Selector queries
    private By _closeModalButtonQ = CssSelector(".close .material-icons");
    private By _continueShoppingButtonQ = CssSelector(".cart-content-btn > .btn.btn-secondary");


    private IWebElement _closeModalButton => FindElement(_closeModalButtonQ);
    private IWebElement _continueShoppingButton => FindElement(_continueShoppingButtonQ);
    #endregion

    public void CloseModal() => _closeModalButton.Click();

    public void ContinueShopping() => _continueShoppingButton.Click();

    public void WaitUntilModalIsVisible() => WaitUntilElementIsVisible(_continueShoppingButtonQ);

}
