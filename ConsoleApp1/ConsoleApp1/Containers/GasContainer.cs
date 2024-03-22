using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Containers;

public class GasContainer : Container, IHazardNotifier
{
    private static int _gasContainerNumber = 1;
    private bool _dangerousObjectInContainer = false;
    private double _pressure = 0;
    
    public GasContainer()
    {
        SerialNumber = GenerateSerialNumber();
    }

    public override void Unload()
    {
        CargoWeightKg *= 0.05;
    }

    public override string GenerateSerialNumber()
    {
        return $"KON-{GetType().Name.Substring(0, 1)}-{_gasContainerNumber}";
    }
    public void Notify()
    {
        _dangerousObjectInContainer = true;
        Console.WriteLine($"Danger in LuquidContainer number : {SerialNumber}");
    }
}