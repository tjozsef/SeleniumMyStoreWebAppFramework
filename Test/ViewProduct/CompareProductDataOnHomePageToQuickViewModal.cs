using SeleniumMyStoreWebAppFramework.DataModel;
using SeleniumMyStoreWebAppFramework.PageObject;

namespace SeleniumMyStoreWebAppFramework.Test.ViewProduct;

public class CompareProductDataOnHomePageToQuickViewModal : BaseTest
{

    [Test]
    public void ComparePopularProductData()
    {
        var homePage = OpenHomePage();
        var popularProductsList = homePage.GetPopularProductsList();
        CompareProductDataOnHomPageAndQuickViewModal(popularProductsList, homePage);
    }

    [Test]
    public void CompareOnSaleProductData()
    {
        var homePage = OpenHomePage();
        var onSaleProductsList = homePage.GetOnSaleProductsList();
        CompareProductDataOnHomPageAndQuickViewModal(onSaleProductsList, homePage);
    }

    [Test]
    public void CompareNewProductData()
    {
        var homePage = OpenHomePage();
        var newProductsList = homePage.GetNewProductsList();
        CompareProductDataOnHomPageAndQuickViewModal(newProductsList, homePage);
    }


    private static void CompareProductDataOnHomPageAndQuickViewModal(IList<Product> productList, HomePage homePage)
    {
        foreach (var product in productList)
        {
            Assert.Multiple(() =>
            {
                Assert.That(homePage.IsImageDisplayed(product.Image), Is.True,
                 $"Image is missing for {product.Name} on homepage.");
                Assert.That(product.Quantity, Is.EqualTo(null),
                $"On home page quantity should not be visible for {product.Name}");
            });

            var quickViewModal = homePage.OpenQuickViewModalForProduct(product);
            var quickViewModalProduct = quickViewModal.GetProduct();
            Assert.Multiple(() =>
            {
                Assert.That(quickViewModalProduct.Name, Does.StartWith(product.Name.Replace(".", "")), "Product name does not match.");
                Assert.That(quickViewModalProduct.Price, Is.EqualTo(product.Price), "Product price doues not match.");
                Assert.That(quickViewModalProduct.RegularPrice, Is.EqualTo(product.RegularPrice), "Product regular price does not match.");
                Assert.That(quickViewModalProduct.Quantity, Is.EqualTo(1), $"Expected default quantity on quick view modal is 1, " +
                "actual : {quickViewModalProduct.Quantity}");
                Assert.That(quickViewModal.IsImageDisplayed(quickViewModalProduct.Image), Is.True, $"Image is missing for {product.Name} on QuickViewModal.");
            });
            quickViewModal.Close();
        }
    }

}