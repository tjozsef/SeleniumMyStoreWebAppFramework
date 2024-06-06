using OpenQA.Selenium;


namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class ProductDetailsPage(IWebDriver driver) : BasePageObject(driver)
    {

        private IWebElement IncreaceProductCount => _driver.FindElement(By.CssSelector(".touchspin-up"));
        private IWebElement DecreaseProductCount => _driver.FindElement(By.CssSelector(".touchspin-down"));
        private IWebElement WishlistButton => _driver.FindElement(By.CssSelector(".wishlist-button-product > .material-icons"));
        private IWebElement ModalHeader => _driver.FindElement(By.CssSelector(".show .modal-header"));
        private IWebElement ModalSpan => _driver.FindElement(By.CssSelector(".show span"));
        private IWebElement ModalCancel => _driver.FindElement(By.CssSelector(".show .modal-cancel"));
        private IWebElement ModalPrimaryButton => _driver.FindElement(By.CssSelector(".show .btn-primary"));
        private IWebElement ShareLink => _driver.FindElement(By.LinkText("Share"));
        private IWebElement TweetLink => _driver.FindElement(By.LinkText("Tweet"));
        private IWebElement PinterestLink => _driver.FindElement(By.LinkText("Pinterest"));
        private IWebElement ZoomIn => _driver.FindElement(By.CssSelector(".zoom-in"));
        private IWebElement ProductModal => _driver.FindElement(By.Id("product-modal"));
        private IWebElement Thumbnail => _driver.FindElement(By.CssSelector(".js-thumb"));
        private IWebElement ProductDetailsLink => _driver.FindElement(By.LinkText("Product Details"));
        private IWebElement DescriptionLink => _driver.FindElement(By.LinkText("Description"));
        private IWebElement AddToCartButton => _driver.FindElement(By.CssSelector(".add-to-cart"));
        private IWebElement CloseContinueShoppingModalButton => _driver.FindElement(By.CssSelector(".close .material-icons"));
        private IWebElement ProceedToCheckoutButton => _driver.FindElement(By.CssSelector(".cart-content-btn > .btn-secondary"));
        private IWebElement ContinueShoppingButton => _driver.FindElement(By.CssSelector(".cart-content-btn > .btn-primary"));

        public void GoToProductDetailsPage(string? PDPUrl)
        {
            if (PDPUrl == null)
            {
                _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk/index.php?id_product=8&rewrite=mug-today-is-a-good-day&controller=product");
                return;
            }
            _driver.Navigate().GoToUrl(PDPUrl);
        }

        public void ClickIncreaseProductCount()
        {
            IncreaceProductCount.Click();
        }

        public void ClickDeacreaseProductCount()
        {
            DecreaseProductCount.Click();
        }

        public void ClickWishlistButton()
        {
            WishlistButton.Click();
        }

        public void ClickModalHeader()
        {
            ModalHeader.Click();
        }

        public void ClickModalSpan()
        {
            ModalSpan.Click();
        }

        public void ClickModalCancel()
        {
            ModalCancel.Click();
        }

        public void ClickModalPrimaryButton()
        {
            ModalPrimaryButton.Click();
        }


        public void ClickShareLink()
        {
            ShareLink.Click();
        }

        public void ClickTweetLink()
        {
            TweetLink.Click();
        }

        public void ClickPinterestLink()
        {
            PinterestLink.Click();
        }

        public void ClickZoomIn()
        {
            ZoomIn.Click();
        }

        public void ClickProductModal()
        {
            ProductModal.Click();
        }

        public void ClickThumbnail()
        {
            Thumbnail.Click();
        }

        public void ClickProductDetailsLink()
        {
            ProductDetailsLink.Click();
        }

        public void ClickDescriptionLink()
        {
            DescriptionLink.Click();
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
        }

        public void ClickCloseContinueShoppingModalButton()
        {
            CloseContinueShoppingModalButton.Click();
        }

        public void ClickProceedToCheckoutButton()
        {
            ProceedToCheckoutButton.Click();
        }

        public void ClickCartContinueShoppingButton()
        {
            ContinueShoppingButton.Click();
        }
    }
}