using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.DataModel;
using SeleniumMyStoreWebAppFramework.PageObject.Card;

namespace SeleniumMyStoreWebAppFramework.PageObject;

public class ProductQuickViewModal(IWebDriver driver) : BasePageObject(driver)
{

    #region Selector queries
    private By _closeModalButtonQ => CssSelector("#index > [tabindex] [aria-hidden]");

    private By _addToCartButtonQ => CssSelector(".add-to-cart");

    //Note ActiveElement() method is a workaround for the issue in which quick view modal elements can't be find 
    //after opening and closing a successfully added modal.
    private IWebElement _quickViewModal => ActiveElement();
    private IWebElement _closeModalButton => FindElement(_closeModalButtonQ);
    private IWebElement _addToCartButton => FindElement(_addToCartButtonQ);

    #endregion

    public void Close() => _closeModalButton.Click();

    public ProductSuccessfullyAddedModal? AddProductToCart()
    {
        if (!_addToCartButton.Enabled) return null;
        _addToCartButton.Click();
        var successfullyAddedModal = new ProductSuccessfullyAddedModal(driver);
        successfullyAddedModal.WaitUntilModalIsVisible();
        return successfullyAddedModal;
    }

    public void ScrollToModal()
    {
        ScrollToWebElement(_quickViewModal);
    }

    public Product GetProduct()
    {
        var product = Product.FromIWebelement(this, _quickViewModal, ProductCardLocators.ForQuickViewModal());
        return product;
    }

    public void WaitUntilModalIsVisible() => WaitUntilElementIsVisible(_addToCartButtonQ);

}

