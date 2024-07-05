
using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.PageObject.Card;

namespace SeleniumMyStoreWebAppFramework.DataModel;
public class Product(double? price, double? regularPrice, string productName, IWebElement productCardElement, IWebElement imageElement)
{
    public double? Price { get; set; } = price;
    public double? RegularPrice { get; set; } = regularPrice;

    public string Name { get; set; } = productName.ToLower();
    public IWebElement ProductCardElement { get; set; } = productCardElement;

    public IWebElement Image { get; set; } = imageElement;

    public static Product FromIWebelement(IWebElement productCardElement, ProductCardLocators cardLocators)
    {
        var productName = productCardElement.FindElement(cardLocators.ProductNameQ).Text;
        var priceStr = productCardElement.FindElement(cardLocators.PriceQ).Text;
        var regularPricesList = productCardElement.FindElements(cardLocators.RegularPriceQ);
        var imageElement = productCardElement.FindElement(cardLocators.ImageQ);
        var regularPriceStr = regularPricesList.Count == 0 ? null : regularPricesList[0].Text;
        return new Product(PriceTagToDouble(priceStr), PriceTagToDouble(regularPriceStr),
        productName, productCardElement, imageElement);
    }
    private static double? PriceTagToDouble(string? price)
    {
        if (price == null || price == "") return null;
        var symbolLessText = price.Replace("$", "");
        symbolLessText = symbolLessText.Replace("€", "");
        return Convert.ToDouble(symbolLessText);
    }

}