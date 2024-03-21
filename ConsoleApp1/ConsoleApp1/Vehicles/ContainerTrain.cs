namespace ConsoleApp1.Vehicles;

public class ContainerTrain : Vehicle
{
    public ContainerTrain(int speed, int currentWeight, int maxWeight, int maxContainerNum) : 
        base(speed, currentWeight, maxWeight, maxContainerNum)
    {
    }
}