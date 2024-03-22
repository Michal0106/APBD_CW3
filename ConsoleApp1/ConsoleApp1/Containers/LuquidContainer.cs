using System.Formats.Asn1;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Containers;

public class LuquidContainer : Container, IHazardNotifier
{
    private static int _luquidContainerNumber = 1;
    private int _privateLuquidContainerNumber { get; set;}
    private bool _dangerousObjectInContainer = false;

    public LuquidContainer()
    {
        SerialNumber = GenerateSerialNumber();
        _privateLuquidContainerNumber = _luquidContainerNumber++;
    }

    public override void Load(int Masa)
    {
        if (_dangerousObjectInContainer)
        {
            if (CargoWeightKg + Masa > 0.5 * MaximumLoadCapacity) Notify();
            else base.Load(Masa);
        }
        else 
        {
            if (CargoWeightKg + Masa > 0.9 * MaximumLoadCapacity) Notify();
            else base.Load(Masa);
        }
    }

    public override string GenerateSerialNumber()
    {
        return $"KON-{GetType().Name.Substring(0, 1)}-{_luquidContainerNumber}";
    }

    public void Notify()
    {
        _dangerousObjectInContainer = true;
        Console.WriteLine($"Danger in LuquidContainer number : {_privateLuquidContainerNumber}");
    }
}