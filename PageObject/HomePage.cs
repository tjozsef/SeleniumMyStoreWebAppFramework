using OpenQA.Selenium;


namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class HomePage(IWebDriver driver) : BasePageObject(driver)
    {

        private const string _pageUrl = "https://teststore.automationtesting.co.uk";

        #region Selector Queries
        private By _firstProductQ = By.XPath("//section[@id='content']/section/div/div/article/div/div/div/a/i");
        private By _secondProductQ = By.XPath("//section[@id='content']/section[2]/div/div/article/div/div/div/a/i");
        private By _addtoCartButtonQ = By.CssSelector(".add-to-cart.btn.btn-primary");
        private By _continueShoppingButtonQ = By.CssSelector(".cart-content-btn [data-dismiss]");
        private By _popularProductsListQ = By.CssSelector(".products.row > div");
        private By _onSaleProductsListQ = By.XPath("//section[@id='content']/section[2]/div/div");
        private By _newProductsListQ = By.XPath("//section[@id='content']/section[3]/div/div");

        private IWebElement _firstProduct => _driver.FindElement(_firstProductQ);
        private IWebElement _secondProduct => _driver.FindElement(_secondProductQ);
        private IWebElement _addtoCartButton => _driver.FindElement(_addtoCartButtonQ);
        private IWebElement _continueShoppingButton => _driver.FindElement(_continueShoppingButtonQ);
        private IList<IWebElement> _popularProductsList => _driver.FindElements(_popularProductsListQ);
        private IList<IWebElement> _onSaleProductsList => _driver.FindElements(_onSaleProductsListQ);
        private IList<IWebElement> _newProductsList => _driver.FindElements(_newProductsListQ);
        #endregion

        public void GoToHomePage() => _driver.Navigate().GoToUrl(_pageUrl);

        public IList<IWebElement> GetPopularProductsList()
        {
            return _popularProductsList;
        }
        public void ClickFirstProduct()
        {
            _firstProduct.Click();
        }

        public void ClickSubmitButton()
        {
            _addtoCartButton.Click();
        }

        public void ClickContinueShoppingButton()
        {
            _continueShoppingButton.Click();
        }

        public void ClickSecondProduct()
        {
            _secondProduct.Click();
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

    }
}