
using OpenQA.Selenium;
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

    public static Product FromIWebelement(IWebElement productCardElement, ProductCardLocators cardLocators)
    {
        var productName = productCardElement.FindElement(cardLocators.ProductNameQ).Text;
        var priceStr = productCardElement.FindElement(cardLocators.PriceQ).Text;
        var regularPricesList = productCardElement.FindElements(cardLocators.RegularPriceQ);
        var regularPriceStr = regularPricesList.Count == 0 ? null : regularPricesList[0].Text;
        var imageElement = productCardElement.FindElement(cardLocators.ImageQ);
        var quantityList = productCardElement.FindElements(cardLocators.QuantityQ);
        var quantityStr = quantityList.Count == 0 ? null : quantityList[0].GetDomAttribute("value");
        return new Product(PriceTagToDouble(priceStr), PriceTagToDouble(regularPriceStr),
        productName, productCardElement, imageElement, QuantityTagToInt(quantityStr));
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