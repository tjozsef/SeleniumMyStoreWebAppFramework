
using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.PageObject;
using SeleniumMyStoreWebAppFramework.PageObject.Card;

namespace SeleniumMyStoreWebAppFramework.DataModel;
public class Product(double? price, double? regularPrice, string productName,
 IWebElement productCardElement, IWebElement imageElement, int? quantity)
{
    public double? Price { get; set; } = price;
    public double? RegularPrice { get; set; } = regularPrice;

    public string Name { get; set; } = productName.ToLower();

    public int? Quantity { get; set; } = quantity;
    public IWebElement ProductCardElement { get; set; } = productCardElement;

    public IWebElement Image { get; set; } = imageElement;

    public static Product FromIWebelement(BasePageObject pageObject, IWebElement productCardElement, ProductCardLocators cardLocators)
    {
        string? quantityStr = GetQuantityStringFromCounterOrText(pageObject, productCardElement, cardLocators);
        var priceStr = productCardElement.FindElement(cardLocators.PriceQ).Text;
        var productName = productCardElement.FindElement(cardLocators.ProductNameQ).Text;
        var imageElement = productCardElement.FindElement(cardLocators.ImageQ);
        var regularPriceStr = GetRegularPriceString(pageObject, productCardElement, cardLocators);
        return new Product(PriceTagToDouble(priceStr), PriceTagToDouble(regularPriceStr),
        productName, productCardElement, imageElement, QuantityTagToInt(quantityStr));
    }

    private static string? GetRegularPriceString(BasePageObject pageObject, IWebElement productCardElement, ProductCardLocators cardLocators)
    {
        if (pageObject is ProductSuccessfullyAddedModal) return null;
        var regularPriceElement = pageObject.FindSubElementOrNullQuickly(productCardElement, cardLocators.RegularPriceQ);
        return regularPriceElement?.Text;
    }

    private static string? GetQuantityStringFromCounterOrText(BasePageObject pageObject, IWebElement productCardElement, ProductCardLocators cardLocators)
    {
        if (pageObject is HomePage) return null;
        var quantityElement = pageObject.FindSubElementOrNullQuickly(productCardElement, cardLocators.QuantityQ);
        if (quantityElement == null) return null;
        var quantityStr = quantityElement.Text == "" ? quantityElement.GetDomAttribute("value") : quantityElement.Text;
        return quantityStr;
    }
    private static double? PriceTagToDouble(string? price)
    {
        if (price == null || price == "") return null;
        var symbolLessText = price.Replace("$", "");
        symbolLessText = symbolLessText.Replace("€", "");
        return Convert.ToDouble(symbolLessText);
    }

    private static int? QuantityTagToInt(string? quantity)
    {
        if (quantity == null || quantity == "") return null;
        return (int)Convert.ToInt32(quantity);
    }

}