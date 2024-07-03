using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppFramework.PageObject.Card
{
    public class ProductCardLocators
    {
        #region On Home Page
        private static string _productNameOnHome = ".js-product-miniature.product-miniature h3 > a";
        private static string _regularPriceOnHome = ".regular-price";
        private static string _priceOnHome = ".price";
        private static string _imageOnHome = "picture";
        #endregion

        #region On Quick View Modal
        private static string _productNameOnQuickViewModal = ".h1";
        private static string _regularPriceOnQuickViewModal = ".modal-content .regular-price";

        private static string _priceOnQuickViewModal = ".current-price-value";

        private static string _imageOnQuickViewModal = ".product-cover > picture > img";
        #endregion

        #region On Cart Page

        #endregion

        public By ProductNameQ;
        public By RegularPriceQ;
        public By PriceQ;

        public By ImageQ;

        private static ProductCardLocators _cardLocatorsForHomePage;

        private static ProductCardLocators _cardLocatorsForQuickViewModal;

        static ProductCardLocators()
        {
            _cardLocatorsForHomePage = new(_productNameOnHome, _regularPriceOnHome, _priceOnHome, _imageOnHome);
            _cardLocatorsForQuickViewModal = new(_productNameOnQuickViewModal, _regularPriceOnQuickViewModal,
             _priceOnQuickViewModal, _imageOnQuickViewModal);
        }

        private ProductCardLocators(string productName, string regularPrice, string price, string image)
        {
            ProductNameQ = By.CssSelector(productName);
            RegularPriceQ = By.CssSelector(regularPrice);
            PriceQ = By.CssSelector(price);
            ImageQ = By.CssSelector(image);
        }


        public static ProductCardLocators ForHomePage() => _cardLocatorsForHomePage;
        public static ProductCardLocators ForQuickViewModal() => _cardLocatorsForQuickViewModal;


        public static ProductCardLocators ForAddedToCartModal()
        {
            throw new NotImplementedException();
        }

        public static ProductCardLocators ForCart()
        {
            throw new NotImplementedException();
        }
    }
}