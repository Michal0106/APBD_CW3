using ConsoleApp1.Exceptions;

namespace ConsoleApp1.Containers;

public class CoolingContainer : Container
{
    private static int _coolingContainerNumber = 1;
        private int _privateCoolingContainerNumber;
        private static Dictionary<string, double>? _allowedProducts;
        private string _loadedProductType;
        private double _containerTemperature;

        public CoolingContainer(Dictionary<string, double> allowedProducts, double containerTemperature)
        {
            SerialNumber = GenerateSerialNumber();
            _privateCoolingContainerNumber = _coolingContainerNumber++;
            _allowedProducts = allowedProducts;
            _loadedProductType = _allowedProducts.Keys.FirstOrDefault();
            _containerTemperature = containerTemperature;
        }

        public override void Load(int mass)
        {
            if (!IsProductTypeAllowed())
            {
                throw new WrongTypeException($"Product type not allowed in cooling container {SerialNumber}");
            }
            if (!IsTemperatureSuitable())
            {
                throw new TemperatureOutOfRangeException($"Temperature out of range for the loaded product in cooling container {SerialNumber}");
            }

            base.Load(mass);
        }

        private bool IsProductTypeAllowed()
        {
            
            if (_allowedProducts == null || _allowedProducts.Count == 0)
            {
                return false;
            }

            return _allowedProducts.ContainsKey(_loadedProductType);
        }

        private bool IsTemperatureSuitable()
        {
            if (_allowedProducts != null && _allowedProducts.TryGetValue(_loadedProductType, out double requiredTemperature))
            {
                return _containerTemperature >= requiredTemperature;
            }
            return false;
        }
    public override string GenerateSerialNumber()
    {
        return $"KON-{GetType().Name.Substring(0, 1)}-{_coolingContainerNumber}";
    }
}