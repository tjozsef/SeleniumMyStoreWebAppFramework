using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.PageObject;

namespace SeleniumMyStoreWebAppFramework.Test.ViewProduct;

public class CompareProductData : BaseTest
{
    private CartPage _cartPage;
    [SetUp]
    public void SetupPage()
    {
        _cartPage = new CartPage(_driver);
    }



    [Test]
    public void ComparePopularProductDataOnHomePageAndQuickViewAndCart()
    {
        var homePage = OpenHomePage();
        var popularProductsList = homePage.GetPopularProductsList();
        foreach (var product in popularProductsList)
        {
            var quickViewModal = homePage.OpenQuickViewModalForProduct(product);
            var quickViewModalProduct = quickViewModal.GetProduct();
            Assert.Multiple(() =>
            {
                Assert.That(quickViewModalProduct.Name, Does.StartWith(product.Name.Replace(".", "")), "Product name does not match.");
                Assert.That(quickViewModalProduct.Price, Is.EqualTo(product.Price), "Product price doues not match.");
                Assert.That(quickViewModalProduct.RegularPrice, Is.EqualTo(product.RegularPrice), "Product regular price does not match.");
            });
            quickViewModal.CloseQuickViewModal();
        }
    }

    private void AddAllProductsToCartCheckProductCount(IList<IWebElement> productsList, HomePage homePage)
    {
        var productsCount = productsList.Count;
        TestContext.Progress.WriteLine($"{productsCount} products visible in the tested section.");
        Assert.That(productsList, Is.Not.Empty, "Expected there are few products in the tested section, actual count is 0.");
        foreach (var item in productsList)
        {
            TestContext.Progress.WriteLine($"Adding the following product to cart: {item}");
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