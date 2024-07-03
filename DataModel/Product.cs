
using OpenQA.Selenium;
using SeleniumMyStoreWebAppFramework.PageObject.Card;

namespace SeleniumMyStoreWebAppFramework.DataModel;
public class Product(double? price, double? regularPrice, string productName, IWebElement element)
{
    public double? Price { get; set; } = price;
    public double? RegularPrice { get; set; } = regularPrice;

    public string Name { get; set; } = productName.ToLower();
    public IWebElement Element { get; set; } = element;

    public static Product FromIWebelement(IWebElement element, ProductCardLocators cardLocators)
    {
        var productNames = element.FindElements(cardLocators.ProductNameQ);

        var productName = element.FindElement(cardLocators.ProductNameQ).Text;
        var priceStr = element.FindElement(cardLocators.PriceQ).Text;
        var regularPricesList = element.FindElements(cardLocators.RegularPriceQ);
        var regularPriceStr = regularPricesList.Count == 0 ? null : regularPricesList[0].Text;
        return new Product(PriceTagToDouble(priceStr), PriceTagToDouble(regularPriceStr), productName, element);
    }
    private static double? PriceTagToDouble(string? price)
    {
        if (price == null || price == "") return null;
        var symbolLessText = price.Replace("$", "");
        symbolLessText = symbolLessText.Replace("€", "");
        return Convert.ToDouble(symbolLessText);
    }

}