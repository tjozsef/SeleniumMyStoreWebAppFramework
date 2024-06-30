using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.PageObject;

namespace SeleniumMyStoreWebAppFramework.Test.Cart;

public class AddProductsPositive : BaseTest
{
    private CartPage _cartPage;
    [SetUp]
    public void SetupPage()
    {
        _cartPage = new CartPage(_driver);
    }

    [Test]
    public void AddAllPopularProductOnHomePageToCart()
    {
        var homePage = OpenHomePage();
        var popularProductsList = homePage.GetPopularProductsList();
        AddAllProducts(popularProductsList, homePage);
    }

    [Test]
    public void AddAllProductsOnSaleOnHomePage()
    {
        var homePage = OpenHomePage();
        var onSaleProductsList = homePage.GetOnSaleProductsList();
        AddAllProducts(onSaleProductsList, homePage);
    }

    [Test]
    public void AddNewProductsOnHomePage()
    {
        var homePage = OpenHomePage();

        var newProductsList = homePage.GetNewProductsList();
        AddAllProducts(newProductsList, homePage);
    }

    private void AddAllProducts(IList<IWebElement> productsList, HomePage homePage)
    {
        var productsCount = productsList.Count;
        TestContext.Progress.WriteLine($"{productsCount} products visible in the tested section.");
        Assert.That(productsList, Is.Not.Empty, "Expected there are few products in the tested section, actual count is 0.");
        foreach (var item in productsList)
        {
            var isAdded = homePage.AddProductToCartWithQuickViewModal(item);
            if (!isAdded)
            {
                productsCount--;
            }
        }
        _cartPage.GoToCartPage();
        var productsInCartCount = _cartPage.GetAllProductCards().Count;
        TestContext.Progress.WriteLine($"Navigated to the Cart page, {productsInCartCount} different products visible inside the cart.");
        Assert.That(productsInCartCount, Is.EqualTo(productsCount));
    }

    private HomePage OpenHomePage()
    {
        var homePage = new HomePage(_driver);
        homePage.GoToHomePage();
        return homePage;
    }


}