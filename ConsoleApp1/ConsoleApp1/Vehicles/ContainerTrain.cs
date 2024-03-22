namespace ConsoleApp1.Vehicles;

public class ContainerTrain : Vehicle
{
    public ContainerTrain(string vehicleType,int speed, int currentWeight, int maxWeight, int maxContainerNum) : 
        base(vehicleType,speed, currentWeight, maxWeight, maxContainerNum)
    {
        
    }
}