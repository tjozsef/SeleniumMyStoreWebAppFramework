using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class AppBar(IWebDriver driver) : BasePageObject(driver)
    {

        #region Selector Queries
        private readonly By _contactUsTextButtonQ = CssSelector("#contact-link");
        private readonly By _myStoreLogoQ = CssSelector(".logo");
        private readonly By _clothesCategoryTabQ = CssSelector("#category-3");
        private readonly By _menClothesQ = CssSelector("#category-4 > .dropdown-item");
        private readonly By _womenClothesQ = CssSelector("#category-5 > .dropdown-item");
        private readonly By _accessoriesCategoryTabQ = CssSelector("#category-6");
        private readonly By _stationeryAccessoriesQ = CssSelector("#category-7 > .dropdown-item");
        private readonly By _homeAccessoriesQ = CssSelector("#category-8 > .dropdown-item");
        private readonly By _artCategoryTabQ = CssSelector("#category-9");
        private readonly By _searchFieldQ = Name("s");
        private readonly By _signedInUserInfoQ = CssSelector(".user-info > a");
        private readonly By _shoppingCartQ = CssSelector(".shopping-cart");
        private readonly By _signInQ = CssSelector("#_desktop_user_info");
        private readonly By _signOutQ = CssSelector(".logout");

        private IWebElement _contactUs => FindElement(_contactUsTextButtonQ);
        private IWebElement _myStoreLogo => FindElement(_myStoreLogoQ);
        private IWebElement _clothesCategoryTab => FindElement(_clothesCategoryTabQ);
        private IWebElement _menClothes => FindElement(_menClothesQ);
        private IWebElement _womenClothes => FindElement(_womenClothesQ);
        private IWebElement _accessoriesCategoryTab => FindElement(_accessoriesCategoryTabQ);
        private IWebElement _stationeryAccessories => FindElement(_stationeryAccessoriesQ);
        private IWebElement _homeAccessories => FindElement(_homeAccessoriesQ);
        private IWebElement _artCategoryTab => FindElement(_artCategoryTabQ);
        private IWebElement _searchField => FindElement(_searchFieldQ);
        private IWebElement _signedInUserInfo => FindElement(_signedInUserInfoQ);
        private IWebElement _shoppingCart => FindElement(_shoppingCartQ);
        private IWebElement _signOut => FindElement(_signOutQ);
        private IWebElement _signIn => FindElement(_signInQ);
        #endregion
        public SignInPage GoToSignInPage()
        {
            _signIn.Click();
            var signInPage = new SignInPage(_driver);
            return signInPage;
        }

        public void GoToContactUsPage()
        {
            _contactUs.Click();
            throw new NotImplementedException("ContactUs page object is unimplemented.");
        }

        public void GoToClothesCategory()
        {
            _clothesCategoryTab.Click();
            throw new NotImplementedException("ClothesCategory page object is unimplemented.");
        }

        public void GoToAccessoriesCategory()
        {
            _accessoriesCategoryTab.Click();
            throw new NotImplementedException("AccessoriesCategory page object is unimplemented.");
        }

        public void GoToArtCategory()
        {
            _artCategoryTab.Click();
            throw new NotImplementedException("ArtCategory page object is unimplemented.");
        }

        public void SearchProductByText(string searchText)
        {
            _searchField.SendKeys(searchText);
            _searchField.SendKeys(Keys.Enter);
            throw new NotImplementedException("SearchResult page object is unimplemented.");
        }

        public void SignOutUser()
        {
            _signOut.Click();
        }

        public HomePage GoToHomePageByStoreLogo()
        {
            _myStoreLogo.Click();
            return new HomePage(_driver);
        }

        public CartPage GoToCartPage()
        {
            _shoppingCart.Click();
            return new CartPage(_driver);
        }

        public bool IsUserSignedIn()
        {
            return IsElementDisplayed(_signOutQ);
        }

    }
}