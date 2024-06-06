using OpenQA.Selenium;

namespace SeleniumMyStoreWebAppTest.PageObject
{
    public class CartPage(IWebDriver driver) : BasePageObject(driver)
    {

        private IWebElement CartAppBarIcon => _driver.FindElement(By.XPath("//div[@id='_desktop_cart']/div/div/a/span"));

        private IWebElement DeleteProductButton => _driver.FindElement(By.XPath("//section[@id='main']/div/div/div/div[2]/ul/li/div/div[3]/div/div[2]/div/div/div/span[3]/button[2]/i"));

        private IWebElement IncreaseQuantityButton => _driver.FindElement(By.XPath("//section[@id='main']/div/div/div/div[2]/ul/li/div/div[3]/div/div[2]/div/div/div/span[3]/button/i"));

        private IWebElement CheckoutButton => _driver.FindElement(By.XPath("//section[@id='main']/div/div/div/div[2]/ul/li/div/div[3]/div/div[3]/div/a/i"));

        private IWebElement PromoCodeTextButton => _driver.FindElement(By.LinkText("Have a promo code?"));

        private IWebElement ProceedToCheckoutButton => _driver.FindElement(By.LinkText("Proceed to checkout"));

        private IWebElement ContinueShoppingTextButton => _driver.FindElement(By.LinkText("chevron_leftContinue shopping"));

        private IWebElement SpecialOffer => _driver.FindElement(By.XPath("//section[@id='main']/div/div[2]/div/div/div[2]/div[2]/span[2]"));

        private  IList<IWebElement> ProductCardsList => _driver.FindElements(By.CssSelector("li .clearfix"));
        public void GotoCartPage()
        {
            _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk/index.php?controller=cart&action=show");
        }

        public void GoToToCheckoutPage()
        {
            _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk/index.php?controller=order");
        }

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl("https://teststore.automationtesting.co.uk/index.php");
        }

        public IList<IWebElement> GetAllProductCards(){
            return ProductCardsList;
        }
    }
}