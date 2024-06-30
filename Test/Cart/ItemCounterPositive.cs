using SeleniumMyStoreWebAppFramework.PageObject;

namespace SeleniumMyStoreWebAppFramework.Test.Cart;

public class ItemCounterPositive : BaseTest
{
    private ProductDetailsPage _productDetailsPage;
    [SetUp]
    public void SetupPage()
    {
        _productDetailsPage = new ProductDetailsPage(_driver);
        _productDetailsPage.GoToProductDetailsPage(null);
    }

    [Test]
    public void IncreaseAndDecreaseCounterInCartToCheckPriceChange()
    {
        var productCounterOnPDD = IncreaseAndDecreaseCounterOnPDP();
        _productDetailsPage.ClickAddToCartButton();
        Assert.That(_productDetailsPage.GetProductCountOnModal(), Is.EqualTo(productCounterOnPDD));
        _productDetailsPage.ClickCloseModalButton();
        var currentPriceOnPDP = _productDetailsPage.GetCurrentPriceTag();
        TestContext.Progress.WriteLine("Navigate to cart page");
        var cartPage = _productDetailsPage.ClickCartButtonOnAppbar();
        var productCountCart = cartPage.GetProductCountForRowNumber(0);
        Assert.That(productCountCart, Is.EqualTo(productCounterOnPDD), $"Product count on PDP and cart expected to be equal, actual" +
         $" PDP:{productCounterOnPDD}, Cart:{productCountCart}");
        var totalPriceForProductOnCart = cartPage.GetTotalProductPriceForRowNumber(0);
        var totalPriceForProductOnPDP = currentPriceOnPDP * productCounterOnPDD;
        Assert.That(Math.Abs(totalPriceForProductOnCart - totalPriceForProductOnPDP), Is.LessThanOrEqualTo(0.01));
        cartPage.ClickIncreaseProductCounterForRowNumber(0);
        //TODO: Assert total price for product changes
    }


    private int IncreaseAndDecreaseCounterOnPDP()
    {
        TestContext.Progress.WriteLine("Increasing product counter on PDP");
        for (int i = 1; i <= 6; i++)
        {
            var count = _productDetailsPage.GetProductCountOnPDP();
            Assert.That(count, Is.EqualTo(i), $"Counter on PDP expected to be {i}, actual {count}");
            _productDetailsPage.ClickIncreaseProductCount();
        }
        TestContext.Progress.WriteLine("Decreasing product counter on PDP");
        for (int i = 7; i >= 3; i--)
        {
            var count = _productDetailsPage.GetProductCountOnPDP();
            Assert.That(count, Is.EqualTo(i), $"Counter on PDP expected to be {i}, actual {count}");
            _productDetailsPage.ClickDeacreaseProductCount();
        }
        return _productDetailsPage.GetProductCountOnPDP();
    }


}