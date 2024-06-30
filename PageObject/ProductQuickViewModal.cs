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

    public void AddProductToCart() => _addToCartButton.Click();

    public void WaitUntilModalIsVisible() => WaitUntilElementIsClickAble(_addToCartButton);

}

