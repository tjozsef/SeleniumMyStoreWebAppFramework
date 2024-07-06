using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.DataModel;
using SeleniumMyStoreWebAppFramework.PageObject.Card;

namespace SeleniumMyStoreWebAppFramework.PageObject;

public class ProductSuccessfullyAddedModal(IWebDriver driver) : BasePageObject(driver)
{

    #region Selector queries
    private By _closeModalButtonQ = CssSelector(".close .material-icons");
    private By _continueShoppingButtonQ = CssSelector(".cart-content-btn > .btn.btn-secondary");


    private IWebElement _closeModalButton => FindElement(_closeModalButtonQ);
    private IWebElement _continueShoppingButton => FindElement(_continueShoppingButtonQ);
    private IWebElement _successfullyAddedModal => ActiveElement();
    #endregion

    public void CloseModal() => _closeModalButton.Click();

    public void ContinueShopping() => _continueShoppingButton.Click();

    public void WaitUntilModalIsVisible() => WaitUntilElementIsVisible(_continueShoppingButtonQ);

    public Product GetProduct()
    {
        var product = Product.FromIWebelement(this, _successfullyAddedModal, ProductCardLocators.ForSuccessfullyAddedModal());
        return product;
    }

}
