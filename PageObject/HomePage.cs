using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class HomePage(IWebDriver driver) : BasePageObject(driver)
    {
        private IWebElement FirstProduct => _driver.FindElement(By.XPath("//section[@id='content']/section/div/div/article/div/div/div/a/i"));
        private IWebElement SecondProduct => _driver.FindElement(By.XPath("//section[@id='content']/section[2]/div/div/article/div/div/div/a/i"));

        private IWebElement AddtoCartButton => _driver.FindElement(By.CssSelector(".add-to-cart.btn.btn-primary"));

        private IWebElement ContinueShoppingButton => _driver.FindElement(By.CssSelector(".cart-content-btn [data-dismiss]"));

        private IList<IWebElement> PopularProductsList => _driver.FindElements(By.CssSelector(".products.row > div"));

        private IList<IWebElement> OnSaleProductsList => _driver.FindElements(By.XPath("//section[@id='content']/section[2]/div/div"));

        private IList<IWebElement> NewProductsList => _driver.FindElements(By.XPath("//section[@id='content']/section[3]/div/div"));

        public void GoToHomePage() => _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk");

        public IList<IWebElement> GetPopularProductsList()
        {
            return PopularProductsList;
        }
        public void ClickFirstProduct()
        {
            FirstProduct.Click();
        }

        public void ClickSubmitButton()
        {
            AddtoCartButton.Click();
        }

        public void ClickContinueShoppingButton()
        {
            ContinueShoppingButton.Click();
        }

        public void ClickSecondProduct()
        {
            SecondProduct.Click();
        }

//TODO: Refactor to use composition or inner class for modal objects
//TODO: Add methods to the BasePageObject to handle scrolling
        public void AddProductToCartWithQuickViewModal(IWebElement productCard)
        {
            HoverMouseOverProductCard(productCard);
            var quickViewTextButton = productCard.FindElement(By.CssSelector(".js-quick-view.quick-view"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(ExpectedConditions.ElementToBeClickable(quickViewTextButton));
            quickViewTextButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(AddtoCartButton));
            AddtoCartButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#blockcart-modal")));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", ContinueShoppingButton);
            ContinueShoppingButton.Click();
        }

        private void HoverMouseOverProductCard(IWebElement productCard)
        {
            var action = new Actions(_driver);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", productCard);
            action.MoveToElement(productCard).Perform();
        }
    }
}