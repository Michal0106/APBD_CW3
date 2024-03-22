using ConsoleApp1.Containers;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Vehicles;

public abstract class Vehicle : IVehicles
{
    private List<Container> _containers;
    private string _vehicleType { get; set; }
    private int _speed { get; }
    private double _currentWeight { get; set; }
    private int _maxWeight { get; }
    private int _maxContainerNum { get; }

    protected Vehicle(string vehicleType, int speed, double currentWeight, int maxWeight, int maxContainerNum)
    {
        _vehicleType = vehicleType;
        _speed = speed;
        _currentWeight = currentWeight;
        _maxWeight = maxWeight;
        _maxContainerNum = maxContainerNum;
    }

    public void Unload()
    {
        _containers.Clear();
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count < _maxContainerNum)
        {
            double totalWeight = _currentWeight + container.CargoWeightKg + container.EmptyWeightKg;
            if (totalWeight <= _maxWeight)
            {
                _containers.Add(container);
                _currentWeight = totalWeight;
            }
            else
            {
                throw new InvalidOperationException("Cannot load container: exceeds maximum weight capacity.");
            }
        }
        else
        {
            throw new InvalidOperationException("Cannot load container: maximum container limit reached.");
        }
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            _containers.Add(container);
        }
    }

    public void Remove(Container container)
    {
        _containers.Remove(container);
    }

    public void Replace(Container currentContainer, Container futureContainer)
    {
        int index = _containers.IndexOf(currentContainer);
        if (index != -1)
        {
            _containers[index] = futureContainer;
        }
        else
        {
            throw new ArgumentException("Current container not found in the list.");
        }
    }
    public void MoveToAnotherVehicle(Container container, Vehicle currentVehicle, Vehicle vehicleToMove)
    {
        if (currentVehicle._containers.Contains(container))
        {
            try
            {
                vehicleToMove.LoadContainer(container);
                currentVehicle.Remove(container);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Moving container failed: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Cannot move container: it's not loaded on the current vehicle.");
        }
    }
    
    public void WriteInfo()
    {
        Console.WriteLine("Vehicle Information:");
        Console.WriteLine($"Vehicle Type: {_vehicleType}");
        Console.WriteLine($"Speed: {_speed} km/h");
        Console.WriteLine($"Maximum Weight: {_maxWeight} kg");
        Console.WriteLine($"Maximum Container Number: {_maxContainerNum}");

        if (_containers.Count > 0)
        {
            Console.WriteLine("Containers:");
            foreach (var container in _containers)
            {
                Console.WriteLine($"- Serial Number: {container.SerialNumber}");
                Console.WriteLine($"  Height: {container.HeightCm} cm");
                Console.WriteLine($"  Depth: {container.DepthCm} cm");
                Console.WriteLine($"  Empty Weight: {container.EmptyWeightKg} kg");
                Console.WriteLine($"  Cargo Weight: {container.CargoWeightKg} kg");
                Console.WriteLine($"  Maximum Load Capacity: {container.MaximumLoadCapacity} kg");
            }
        }
        else
        {
            Console.WriteLine("No containers loaded.");
        }
    }
    
    
}