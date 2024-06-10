using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class CartPage(IWebDriver driver) : BasePageObject(driver)
    {
        private const string _cartPageUrl = "https://teststore.automationtesting.co.uk/index.php?controller=cart&action=show";
        private const string _checkoutPageUrl = "https://teststore.automationtesting.co.uk/index.php?controller=order";


        #region  Selector Queries
        private By _cartAppBarIconQ = By.XPath("//div[@id='_desktop_cart']/div/div/a/span");
        private By _deleteProductButtonQ = By.XPath("//section[@id='main']/div/div/div/div[2]/ul/li/div/div[3]/div/div[2]/div/div/div/span[3]/button[2]/i");
        private By _increaseQuantityButtonQ = By.XPath("//section[@id='main']/div/div/div/div[2]/ul/li/div/div[3]/div/div[2]/div/div/div/span[3]/button/i");
        private By _checkoutButtonQ = By.XPath("//section[@id='main']/div/div/div/div[2]/ul/li/div/div[3]/div/div[3]/div/a/i");
        private By _promoCodeTextButtonQ = By.LinkText("Have a promo code?");
        private By _proceedToCheckoutButtonQ = By.LinkText("Proceed to checkout");
        private By _continueShoppingTextButtonQ = By.LinkText("chevron_leftContinue shopping");
        private By _specialOfferQ = By.XPath("//section[@id='main']/div/div[2]/div/div/div[2]/div[2]/span[2]");
        private By _productCardsListQ = By.CssSelector("li .clearfix");

        private IWebElement _cartAppBarIcon => _driver.FindElement(_cartAppBarIconQ);
        private IWebElement _deleteProductButton => _driver.FindElement(_deleteProductButtonQ);
        private IWebElement _increaseQuantityButton => _driver.FindElement(_increaseQuantityButtonQ);
        private IWebElement _checkoutButton => _driver.FindElement(_checkoutButtonQ);
        private IWebElement _promoCodeTextButton => _driver.FindElement(_promoCodeTextButtonQ);
        private IWebElement _proceedToCheckoutButton => _driver.FindElement(_proceedToCheckoutButtonQ);
        private IWebElement _continueShoppingTextButton => _driver.FindElement(_continueShoppingTextButtonQ);
        private IWebElement _specialOffer => _driver.FindElement(_specialOfferQ);
        private IList<IWebElement> _productCardsList => _driver.FindElements(_productCardsListQ);
        #endregion
        public void GoToCartPage() => GoToUrl(_cartPageUrl);


        public void GoToToCheckoutPage()
        {
            _driver.Navigate().GoToUrl(_checkoutPageUrl);
        }

        public HomePage GoToHomePage()
        {
            return new HomePage(_driver);
        }

        public IList<IWebElement> GetAllProductCards()
        {
            return _productCardsList;
        }
    }
}