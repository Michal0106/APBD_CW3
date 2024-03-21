using System.Formats.Asn1;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Containers;

public class LuquidContainer : Container, IHazardNotifier
{
    public static int LuquidContainerNumber = 1;
    public int PrivateLuquidContainerNumber { get; set;}
    private bool DangerousObjectInContainer = false;

    public LuquidContainer()
    {
        SerialNumber = GenerateSerialNumber();
        PrivateLuquidContainerNumber = LuquidContainerNumber++;
    }

    public override void Load(int Masa)
    {
        if (DangerousObjectInContainer)
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
        return $"KON-{GetType().Name.Substring(0, 1)}-{LuquidContainerNumber}";
    }

    public void Notify()
    {
        DangerousObjectInContainer = true;
        Console.WriteLine($"Danger in LuquidContainer number : {PrivateLuquidContainerNumber}");
    }
}