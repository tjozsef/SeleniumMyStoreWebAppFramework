using SeleniumMyStoreWebAppFramework.DataModel;
using SeleniumMyStoreWebAppFramework.PageObject;

namespace SeleniumMyStoreWebAppFramework.Test.ViewProduct;

public class CheckImagesForProducts : BaseTest
{

    [Test]
    public void CheckImagesForPopularProducts()
    {
        var homePage = OpenHomePage();
        var popularProductsList = homePage.GetPopularProductsList();
        CheckImagesDisplayedForProducts(popularProductsList, homePage);
    }

    [Test]
    public void CheckImagesForOnSaleProducts()
    {
        var homePage = OpenHomePage();
        var onSaleProductsList = homePage.GetOnSaleProductsList();
        CheckImagesDisplayedForProducts(onSaleProductsList, homePage);
    }

    [Test]
    public void CheckImagesForNewProducts()
    {
        var homePage = OpenHomePage();
        var newProductsList = homePage.GetNewProductsList();
        CheckImagesDisplayedForProducts(newProductsList, homePage);
    }


    private static void CheckImagesDisplayedForProducts(IList<Product> productList, HomePage homePage)
    {
        foreach (var productOnHome in productList)
        {
            TestContext.Progress.WriteLine(
                $"Checking images for {productOnHome.Name}"
            );
            Assert.That(homePage.IsImageDisplayed(productOnHome.Image), Is.True,
            $"Image is missing for {productOnHome.Name} on HomePage.");
            var quickViewModal = homePage.OpenQuickViewModalForProduct(productOnHome);
            var quickViewModalProduct = quickViewModal.GetProduct();
            Assert.That(quickViewModal.IsImageDisplayed(quickViewModalProduct.Image), Is.True,
            $"Image is missing for {productOnHome.Name} on QuickViewModal.");
            var successfullyAddedModal = quickViewModal.AddProductToCart();
            if (successfullyAddedModal == null)
            {
                TestContext.Progress.WriteLine($"Product: {productOnHome.Name} can not be added to cart, add to cart button is disabled.");
                quickViewModal.Close();
                continue;
            }
            var successfullyAddedModalProduct = successfullyAddedModal.GetProduct();
            successfullyAddedModal.IsImageDisplayed(successfullyAddedModalProduct.Image);
            successfullyAddedModal.ContinueShopping();
        }
    }

}