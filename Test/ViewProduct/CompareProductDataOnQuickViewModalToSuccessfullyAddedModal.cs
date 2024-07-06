using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.PageObject;

namespace SeleniumMyStoreWebAppFramework.Test.ViewProduct;

public class CompareProductDataOnQuickViewModalToSuccessfullyAddedModal : BaseTest
{

    [Test]
    public void ComparePopularProductData()
    {
        var homePage = OpenHomePage();
        var popularProductsList = homePage.GetPopularProductsElementList();
        CompareProductDataQuickViewModalToSuccessfullyAddedModal(popularProductsList, homePage);
    }

    [Test]
    public void CompareOnSaleProductData()
    {
        var homePage = OpenHomePage();
        var onSaleProductsList = homePage.GetOnSaleProductsElementList();
        CompareProductDataQuickViewModalToSuccessfullyAddedModal(onSaleProductsList, homePage);
    }

    [Test]
    public void CompareNewProductData()
    {
        var homePage = OpenHomePage();
        var newProductsList = homePage.GetNewProductsElementList();
        CompareProductDataQuickViewModalToSuccessfullyAddedModal(newProductsList, homePage);
    }

    private static void CompareProductDataQuickViewModalToSuccessfullyAddedModal(IList<IWebElement> productList, HomePage homePage)
    {
        foreach (var product in productList)
        {
            var quickViewModal = homePage.OpenQuickViewModalForProduct(product);
            var productOnQuickViewModal = quickViewModal.GetProduct();
            var successfullyAddedModal = quickViewModal.AddProductToCart();
            if (successfullyAddedModal == null)
            {
                TestContext.Progress.WriteLine($"Product: {productOnQuickViewModal.Name} can not be added to cart, add to cart button is disabled.");
                quickViewModal.Close();
                continue;
            }
            var productOnSuccessFullyAddedModal = successfullyAddedModal!.GetProduct();
            Assert.Multiple(() =>
            {
                Assert.That(successfullyAddedModal.IsImageDisplayed(productOnSuccessFullyAddedModal.Image), Is.True,
                $"Image is not displayed on successfully added modal for {productOnSuccessFullyAddedModal.Name}");

                Assert.That(productOnSuccessFullyAddedModal.Name, Is.EqualTo(productOnQuickViewModal.Name),
                $"Product name is different on  successfully added and quick view and modal: "
                + $"{productOnQuickViewModal.Name} vs {productOnSuccessFullyAddedModal.Name}");

                Assert.That(productOnSuccessFullyAddedModal.Price, Is.EqualTo(productOnQuickViewModal.Price),
                $"Product price is different on  successfully added and quick view and modal: "
               + $"{productOnQuickViewModal.Name} vs {productOnSuccessFullyAddedModal.Name}");

                Assert.That(productOnSuccessFullyAddedModal.Quantity, Is.EqualTo(productOnQuickViewModal.Quantity),
               $"Product quantity is different on  successfully added and quick view and modal: "
               + $"{productOnQuickViewModal.Name} vs {productOnSuccessFullyAddedModal.Name}");
            });
            successfullyAddedModal.ContinueShopping();
        }
    }
}