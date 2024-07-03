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



    private HomePage OpenHomePage()
    {
        var homePage = new HomePage(_driver);
        homePage.GoToHomePage();
        return homePage;
    }


}