using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.DataModel;
using SeleniumMyStoreWebAppFramework.PageObject.Card;

namespace SeleniumMyStoreWebAppFramework.PageObject;

public class ProductQuickViewModal(IWebDriver driver) : BasePageObject(driver)
{

    #region Selector queries
    private By _closeModalButtonQ = CssSelector("#index > div[role='dialog'] .close");

    private By _addToCartButtonQ = CssSelector(".add-to-cart");

    private By _quickViewModalQ = CssSelector("#index > [tabindex] .modal-content");

    private IWebElement _quickViewModal => FindElement(_quickViewModalQ);
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

    public Product GetProduct()
    {
        var product = Product.FromIWebelement(_quickViewModal, ProductCardLocators.ForQuickViewModal());
        return product;
    }

    public void WaitUntilModalIsVisible() => WaitUntilElementIsVisible(_addToCartButtonQ);

}

