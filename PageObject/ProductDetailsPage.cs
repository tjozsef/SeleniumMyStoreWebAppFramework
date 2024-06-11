using OpenQA.Selenium;


namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class ProductDetailsPage(IWebDriver driver) : BasePageObject(driver)
    {
        private const string _productDetailsPageUrl = "https://teststore.automationtesting.co.uk/index.php?id_product=8&rewrite=mug-today-is-a-good-day&controller=product";
        #region Selector Queries
        private By _increaceProductCountQ = By.CssSelector(".touchspin-up");
        private By _decreaseProductCountQ = By.CssSelector(".touchspin-down");
        private By _productCounterQ = By.CssSelector("#quantity_wanted");
        private By _cartButtonOnAppbarQ = By.CssSelector("#_desktop_cart");
        private By _wishlistButtonQ = By.CssSelector(".wishlist-button-product > .material-icons");
        private By _productCounterOnModalQ = By.CssSelector("strong");
        private By _currentPriceTagQ = By.CssSelector(".current-price-value");
        private By _modalHeaderQ = By.CssSelector(".show .modal-header");
        private By _modalSpanQ = By.CssSelector(".show span");
        private By _modalCancelQ = By.CssSelector(".show .modal-cancel");
        private By _modalPrimaryButtonQ = By.CssSelector(".show .btn-primary");
        private By _shareLinkQ = By.LinkText("Share");
        private By _tweetLinkQ = By.LinkText("Tweet");
        private By _pinterestLinkQ = By.LinkText("Pinterest");
        private By _zoomInQ = By.CssSelector(".zoom-in");
        private By _productModalQ = By.Id("product-modal");
        private By _thumbnailQ = By.CssSelector(".js-thumb");
        private By _productDetailsLinkQ = By.LinkText("Product Details");
        private By _descriptionLinkQ = By.LinkText("Description");
        private By _addToCartButtonQ = By.CssSelector(".add-to-cart");
        private By _closeModalButtonQ = By.CssSelector(".close .material-icons");
        private By _proceedToCheckoutButtonQ = By.CssSelector(".cart-content-btn > .btn-secondary");
        private By _continueShoppingButtonQ = By.CssSelector(".cart-content-btn > .btn-primary");

        private IWebElement _increaceProductCount => _driver.FindElement(_increaceProductCountQ);
        private IWebElement _decreaseProductCount => _driver.FindElement(_decreaseProductCountQ);
        private IWebElement _productCounterOnPDP => _driver.FindElement(_productCounterQ);
        private IWebElement _productCounterOnModal => _driver.FindElement(_productCounterOnModalQ);
        private IWebElement _currentPriceTag => FindElement(_currentPriceTagQ);
        private IWebElement _cartButtonOnAppbar => _driver.FindElement(_cartButtonOnAppbarQ);
        private IWebElement _wishlistButton => _driver.FindElement(_wishlistButtonQ);
        private IWebElement _modalHeader => _driver.FindElement(_modalHeaderQ);
        private IWebElement _modalSpan => _driver.FindElement(_modalSpanQ);
        private IWebElement _modalCancel => _driver.FindElement(_modalCancelQ);
        private IWebElement _modalPrimaryButton => _driver.FindElement(_modalPrimaryButtonQ);
        private IWebElement _shareLink => _driver.FindElement(_shareLinkQ);
        private IWebElement _tweetLink => _driver.FindElement(_tweetLinkQ);
        private IWebElement _pinterestLink => _driver.FindElement(_pinterestLinkQ);
        private IWebElement _zoomIn => _driver.FindElement(_zoomInQ);
        private IWebElement _productModal => _driver.FindElement(_productModalQ);
        private IWebElement _thumbnail => _driver.FindElement(_thumbnailQ);
        private IWebElement _productDetailsLink => _driver.FindElement(_productDetailsLinkQ);
        private IWebElement _descriptionLink => _driver.FindElement(_descriptionLinkQ);
        private IWebElement _addToCartButton => _driver.FindElement(_addToCartButtonQ);
        private IWebElement _closeModalButton => _driver.FindElement(_closeModalButtonQ);
        private IWebElement _proceedToCheckoutButton => _driver.FindElement(_proceedToCheckoutButtonQ);
        private IWebElement _continueShoppingButton => _driver.FindElement(_continueShoppingButtonQ);
        #endregion
        public void GoToProductDetailsPage(string? PDPUrl)
        {
            if (PDPUrl == null)
            {
                GoToUrl(_productDetailsPageUrl);
                return;
            }
            GoToUrl(PDPUrl);
        }

        public void ClickIncreaseProductCount()
        {
            _increaceProductCount.Click();
        }

        public void ClickDeacreaseProductCount()
        {
            _decreaseProductCount.Click();
        }

        public int GetProductCountOnPDP() => GetCountOnElement(_productCounterOnPDP);


        public int GetProductCountOnModal() => GetCountOnElementWithWaitUntilVisible(_productCounterOnModalQ);

        public CartPage ClickCartButtonOnAppbar()
        {
            _cartButtonOnAppbar.Click();
            return new CartPage(_driver);
        }

        public void ClickWishlistButton()
        {
            _wishlistButton.Click();
        }

        public void ClickModalHeader()
        {
            _modalHeader.Click();
        }

        public void ClickModalSpan()
        {
            _modalSpan.Click();
        }

        public void ClickModalCancel()
        {
            _modalCancel.Click();
        }

        public void ClickModalPrimaryButton()
        {
            _modalPrimaryButton.Click();
        }


        public void ClickShareLink()
        {
            _shareLink.Click();
        }

        public void ClickTweetLink()
        {
            _tweetLink.Click();
        }

        public void ClickPinterestLink()
        {
            _pinterestLink.Click();
        }

        public void ClickZoomIn()
        {
            _zoomIn.Click();
        }

        public void ClickProductModal()
        {
            _productModal.Click();
        }

        public void ClickThumbnail()
        {
            _thumbnail.Click();
        }

        public void ClickProductDetailsLink()
        {
            _productDetailsLink.Click();
        }

        public void ClickDescriptionLink()
        {
            _descriptionLink.Click();
        }

        public void ClickAddToCartButton()
        {
            _addToCartButton.Click();
        }

        public void ClickCloseModalButton()
        {
            _closeModalButton.Click();
        }

        public void ClickProceedToCheckoutButton()
        {
            _proceedToCheckoutButton.Click();
        }

        public void ClickCartContinueShoppingButton()
        {
            _continueShoppingButton.Click();
        }

        public double GetCurrentPriceTag() => GetNumberOnElement(_currentPriceTag);
    }
}