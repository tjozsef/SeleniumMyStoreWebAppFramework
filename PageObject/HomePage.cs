using OpenQA.Selenium;


namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class HomePage(IWebDriver driver) : BasePageObject(driver)
    {

        private const string _homePageUrl = "https://teststore.automationtesting.co.uk";

        private readonly AppBar _appBar = new(driver);

        #region Selector Queries

        private By _addtoCartButtonQ = CssSelector(".add-to-cart.btn.btn-primary");
        private By _continueShoppingButtonQ = CssSelector(".cart-content-btn [data-dismiss]");
        private By _popularProductsListQ = CssSelector(".products.row > div");
        private By _onSaleProductsListQ = XPath("//section[@id='content']/section[2]/div/div");
        private By _newProductsListQ = XPath("//section[@id='content']/section[3]/div/div");

        private IWebElement _firstPopularProduct => FindElement(_popularProductsListQ);
        private IWebElement _firstOnSaleProduct => FindElement(_onSaleProductsListQ);
        private IWebElement _addtoCartButton => FindElement(_addtoCartButtonQ);
        private IWebElement _continueShoppingButton => FindElement(_continueShoppingButtonQ);
        private IList<IWebElement> _popularProductsList => FindElements(_popularProductsListQ);
        private IList<IWebElement> _onSaleProductsList => FindElements(_onSaleProductsListQ);
        private IList<IWebElement> _newProductsList => FindElements(_newProductsListQ);
        #endregion

        public void GoToHomePage() => GoToUrl(_homePageUrl);

        public IList<IWebElement> GetPopularProductsList()
        {
            return _popularProductsList;
        }
        public void ClickFirstPopularProduct()
        {
            _firstPopularProduct.Click();
        }

        public void ClickSubmitButton()
        {
            _addtoCartButton.Click();
        }

        public void ClickContinueShoppingButton()
        {
            _continueShoppingButton.Click();
        }



        //TODO: Refactor to use composition or inner class for modal objects
        public void AddProductToCartWithQuickViewModal(IWebElement productCard)
        {
            ScrollAndHoverMouseOverWebElement(productCard);
            var quickViewTextButton = productCard.FindElement(By.CssSelector(".js-quick-view.quick-view"));
            WaitUntilElementIsClickAble(quickViewTextButton);
            quickViewTextButton.Click();
            WaitUntilElementIsClickAble(_addtoCartButton);
            _addtoCartButton.Click();
            WaitUntilElementIsVisible(By.CssSelector("#blockcart-modal"));
            ScrollToWebElement(productCard);
            _continueShoppingButton.Click();
        }

        public bool IsUserSignedIn() => _appBar.IsUserSignedIn();

    }
}