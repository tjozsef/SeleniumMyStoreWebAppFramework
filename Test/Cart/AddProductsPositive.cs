using SeleniumMyStoreWebAppTest.PageObject;

namespace SeleniumMyStoreWebAppTest.Cart;

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
        var homePage = new HomePage(_driver);
        homePage.GoToHomePage();
        var popularProductList = homePage.GetPopularProductsList();
        var popularProductsCount = popularProductList.Count;
        TestContext.Progress.WriteLine($"{popularProductsCount} products visible in popular section.");
        Assert.That(popularProductList, Is.Not.Empty, "Expected there are few popular products on homepage, actual count is 0.");
        foreach (var item in popularProductList)
        {
            homePage.AddProductToCartWithQuickViewModal(item);
        }
        _cartPage.GoToCartPage();
        var productsInCartCount = _cartPage.GetAllProductCards().Count;
        TestContext.Progress.WriteLine($"Navigated to the Cart page, {productsInCartCount} different products visible inside the cart.");
        Assert.That(productsInCartCount, Is.EqualTo(popularProductsCount));
    }



}