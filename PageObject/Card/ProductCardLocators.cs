using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppFramework.PageObject.Card
{
    public class ProductCardLocators
    {
        #region On Home Page
        private static string _productNameOnHome = ".js-product-miniature.product-miniature h3 > a";
        private static string _regularPriceOnHome = ".js-product-miniature.product-miniature .regular-price";
        private static string _priceOnHome = ".price";
        private static string _imageOnHome = "picture";
        //Note quantity on home page is not visible.
        private static string _quantityOnHomePage = "null";

        #endregion

        #region On Quick View Modal
        private static string _productNameOnQuickViewModal = ".h1";
        private static string _regularPriceOnQuickViewModal = ".modal-content .regular-price";

        private static string _priceOnQuickViewModal = ".current-price-value";

        private static string _imageOnQuickViewModal = ".product-cover > picture > img";

        private static string _quantityOnQuickViewModal = "#quantity_wanted";
        #endregion

        #region On Successfully Added Modal
        private static string _productNameOnSuccessfullyAddedModal = ".product-name";
        //Note regular price is not visible on Successfully added modal.
        private static string _regularPriceOnSuccessfullyAddedModal = ".modal-content .regular-price";

        private static string _priceOnSuccessfullyAddedModal = ".product-price";

        private static string _imageOnSuccessfullyAddedModal = ".product-image";

        private static string _quantityOnSuccessfullyAddedModal = ".product-quantity strong";
        #endregion

        #region On Cart Page

        #endregion

        public By ProductNameQ;
        public By RegularPriceQ;
        public By PriceQ;
        public By ImageQ;

        public By QuantityQ;

        private static ProductCardLocators _cardLocatorsForHomePage;

        private static ProductCardLocators _cardLocatorsForQuickViewModal;

        private static ProductCardLocators _cardLocatorsForSuccessfullyAddedModal;

        static ProductCardLocators()
        {
            _cardLocatorsForHomePage = new(_productNameOnHome, _regularPriceOnHome, _priceOnHome,
             _imageOnHome, _quantityOnHomePage);

            _cardLocatorsForQuickViewModal = new(_productNameOnQuickViewModal, _regularPriceOnQuickViewModal,
             _priceOnQuickViewModal, _imageOnQuickViewModal, _quantityOnQuickViewModal);

            _cardLocatorsForSuccessfullyAddedModal = new(_productNameOnSuccessfullyAddedModal, _regularPriceOnSuccessfullyAddedModal,
            _priceOnSuccessfullyAddedModal, _imageOnSuccessfullyAddedModal, _quantityOnSuccessfullyAddedModal);
        }

        private ProductCardLocators(string productName, string regularPrice, string price, string image, string quantity)
        {
            ProductNameQ = By.CssSelector(productName);
            RegularPriceQ = By.CssSelector(regularPrice);
            PriceQ = By.CssSelector(price);
            ImageQ = By.CssSelector(image);
            QuantityQ = By.CssSelector(quantity);
        }


        public static ProductCardLocators ForHomePage() => _cardLocatorsForHomePage;
        public static ProductCardLocators ForQuickViewModal() => _cardLocatorsForQuickViewModal;

        public static ProductCardLocators ForSuccessfullyAddedModal() => _cardLocatorsForSuccessfullyAddedModal;

        public static ProductCardLocators ForCart()
        {
            throw new NotImplementedException();
        }
    }
}