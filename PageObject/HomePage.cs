using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.DataModel;
using SeleniumMyStoreWebAppFramework.PageObject.Card;


namespace SeleniumMyStoreWebAppFramework.PageObject
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
        private By _quickViewTextButtonQ = CssSelector(".js-quick-view.quick-view");

        private IWebElement _firstPopularProduct => FindElement(_popularProductsListQ);
        private IWebElement _firstOnSaleProduct => FindElement(_onSaleProductsListQ);
        private IWebElement _addtoCartButton => FindElement(_addtoCartButtonQ);
        private IWebElement _continueShoppingButton => FindElement(_continueShoppingButtonQ);
        private IList<IWebElement> _popularProductsList => FindElements(_popularProductsListQ);
        private IList<IWebElement> _onSaleProductsList => FindElements(_onSaleProductsListQ);
        private IList<IWebElement> _newProductsList => FindElements(_newProductsListQ);
        #endregion

        public void GoToHomePage() => GoToUrl(_homePageUrl);

        public IList<IWebElement> GetPopularProductsElementList() => _popularProductsList;

        public IList<IWebElement> GetOnSaleProductsElementList() => _onSaleProductsList;

        public IList<IWebElement> GetNewProductsElementList() => _newProductsList;

        public IList<Product> GetPopularProductsList() => GetProductsList(_popularProductsList);

        public IList<Product> GetOnSaleProductsList() => GetProductsList(_onSaleProductsList);
        public IList<Product> GetNewProductsList() => GetProductsList(_newProductsList);




        public IList<Product> GetProductsList(IList<IWebElement> elementList)
        {
            IList<Product> productList = [];
            foreach (var element in elementList)
            {
                var product = Product.FromIWebelement(this, element, ProductCardLocators.ForHomePage());
                productList.Add(product);
            }
            return productList;
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



        public bool AddProductToCartWithQuickViewModal(IWebElement productCard)
        {
            var quickViewModal = OpenQuickViewModalForProduct(productCard);
            var successfullyAddedModal = quickViewModal.AddProductToCart();
            ScrollToWebElement(productCard);
            if (successfullyAddedModal == null)
            {
                quickViewModal.Close();
                return false;
            }
            successfullyAddedModal.ContinueShopping();
            return true;
        }

        public ProductQuickViewModal OpenQuickViewModalForProduct(Product product) => OpenQuickViewModalForProduct(product.ProductCardElement);
        public ProductQuickViewModal OpenQuickViewModalForProduct(IWebElement productCard)
        {
            ScrollAndHoverMouseOverWebElement(productCard);
            var quickViewTextButton = productCard.FindElement(_quickViewTextButtonQ);
            WaitUntilElementIsClickAble(quickViewTextButton);
            quickViewTextButton.Click();
            var quickViewModal = new ProductQuickViewModal(driver);
            quickViewModal.WaitUntilModalIsVisible();
            return quickViewModal;
        }

        public bool IsUserSignedIn() => _appBar.IsUserSignedIn();

    }
}