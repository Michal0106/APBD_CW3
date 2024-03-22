namespace ConsoleApp1.Vehicles;

public class ContainerShip : Vehicle
{
    public string VehicleType { get; set; }
    
    public ContainerShip(string vehicleType,int speed, int currentWeight, int maxWeight, int maxContainerNum) : 
        base(vehicleType,speed, currentWeight, maxWeight, maxContainerNum)
    {
        
    }
}