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
        foreach (var productOnHome in productList)
        {
            Assert.Multiple(() =>
            {
                Assert.That(homePage.IsImageDisplayed(productOnHome.Image), Is.True,
                 $"Image is missing for {productOnHome.Name} on homepage.");
                Assert.That(productOnHome.Quantity, Is.EqualTo(null),
                $"On home page quantity should not be visible for {productOnHome.Name}");
            });

            var quickViewModal = homePage.OpenQuickViewModalForProduct(productOnHome);
            var quickViewModalProduct = quickViewModal.GetProduct();
            Assert.Multiple(() =>
            {
                Assert.That(quickViewModalProduct.Name, Does.StartWith(productOnHome.Name.Replace(".", "")),
                "Product name does not match on home page and quick view modal: "
                 + $"{productOnHome.Name} vs {quickViewModalProduct.Name}");

                Assert.That(quickViewModalProduct.Price, Is.EqualTo(productOnHome.Price),
                $"Product price does not match on home page and quick view modal for {productOnHome.Name}: "
                 + $"{productOnHome.Price} vs {quickViewModalProduct.Price}");

                Assert.That(quickViewModalProduct.RegularPrice, Is.EqualTo(productOnHome.RegularPrice),
                $"Product regular price does not match on home page and quick view modal for {productOnHome.Name}: "
                 + $"{productOnHome.RegularPrice} vs {quickViewModalProduct.RegularPrice}");

                Assert.That(quickViewModalProduct.Quantity, Is.EqualTo(1),
                $"Expected default quantity on quick view modal is 1  for {productOnHome.Name}:, " +
                $"actual : {quickViewModalProduct.Quantity}");
                Assert.That(quickViewModal.IsImageDisplayed(quickViewModalProduct.Image), Is.True, $"Image is missing for {productOnHome.Name} on QuickViewModal.");
            });
            quickViewModal.Close();
        }
    }

}