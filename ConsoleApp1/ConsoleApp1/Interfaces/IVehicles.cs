using System.Runtime.InteropServices;
using ConsoleApp1.Containers;
using ConsoleApp1.Vehicles;

namespace ConsoleApp1.Interfaces;

public interface IVehicles
{
    void Unload();
    void LoadContainer(Container container);
    void LoadContainers(List<Container> containers);
    void Remove(Container container);
    void Replace(Container currentContainer, Container futureContainer);
    void MoveToAnotherVehicle(Container container, Vehicle currentVehicle, Vehicle vehicleToMove);
    void WriteInfo();
}