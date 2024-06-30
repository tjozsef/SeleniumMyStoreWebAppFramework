using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppFramework.PageObject;

class ProductQuickViewModal(IWebDriver driver) : BasePageObject(driver)
{

    #region Selector queries
    private By _closeModalButtonQ = CssSelector("#index > div[role='dialog'] .close");

    private By _addToCartButtonQ = CssSelector(".add-to-cart");

    private IWebElement _closeModalButton => FindElement(_closeModalButtonQ);
    private IWebElement _addToCartButton => FindElement(_addToCartButtonQ);
    #endregion

    public void CloseQuickViewModal() => _closeModalButton.Click();

    public ProductSuccessfullyAddedModal? AddProductToCart()
    {
        if (!_addToCartButton.Enabled) return null;
        _addToCartButton.Click();
        var successfullyAddedModal = new ProductSuccessfullyAddedModal(driver);
        successfullyAddedModal.WaitUntilModalIsVisible();
        return successfullyAddedModal;
    }

    public void WaitUntilModalIsVisible() => WaitUntilElementIsVisible(_addToCartButtonQ);

}

