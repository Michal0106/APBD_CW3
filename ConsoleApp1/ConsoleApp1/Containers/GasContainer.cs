using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Containers;

public class GasContainer : Container, IHazardNotifier
{
    private static int GasContainerNumber = 1;
    private int PrivateGasContainerNumber;
    private bool DangerousObjectInContainer = false;
    private double Pressure = 0;
    
    public GasContainer()
    {
        SerialNumber = GenerateSerialNumber();
        PrivateGasContainerNumber = GasContainerNumber++;
    }

    public override void Unload()
    {
        CargoWeightKg *= 0.05;
    }

    public override string GenerateSerialNumber()
    {
        return $"KON-{GetType().Name.Substring(0, 1)}-{GasContainerNumber}";
    }
    public void Notify()
    {
        DangerousObjectInContainer = true;
        Console.WriteLine($"Danger in LuquidContainer number : {SerialNumber}");
    }
}