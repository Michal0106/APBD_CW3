using ConsoleApp1.Exceptions;

namespace ConsoleApp1.Containers;

public class CoolingContainer : Container
{
    private static int _coolingContainerNumber = 1;
    private int _privateCoolingContainerNumber;
    private static Dictionary<string, double>? _allowedProducts;
    private double _containerTemperature;
    private string _productType;
    public CoolingContainer(string productType, double containerTemperature)
    {
        SerialNumber = GenerateSerialNumber();
        _privateCoolingContainerNumber = _coolingContainerNumber++;
        _allowedProducts = InitializeAllowedProducts();
        _productType = productType;
        _containerTemperature = containerTemperature;
    }

    public void Load(int Masa,string Product)
    {
        if (Product != _productType)
        {
            throw new WrongTypeException("This container stores different products");
        }
        if (_containerTemperature >= _allowedProducts[Product]) base.Load(Masa);
    }

    public Dictionary<string, double>? InitializeAllowedProducts()
    {
        return new Dictionary<string, double>()
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };
    }
    public override string GenerateSerialNumber()
    {
        return $"KON-{GetType().Name.Substring(0, 1)}-{_coolingContainerNumber}";
    }
}