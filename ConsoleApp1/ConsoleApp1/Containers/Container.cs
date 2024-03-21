using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Containers
{
    public abstract class Container : IContainer
    {
        public double CargoWeightKg { get; set; }
        public int HeightCm { get; set; }
        public double EmptyWeightKg { get; set; }
        public int DepthCm { get; set; }
        public string SerialNumber { get; set; }
        public double MaximumLoadCapacity { get; set; }

        public virtual void Unload()
        {
            CargoWeightKg = 0;
        }

        public virtual void Load(int weight)
        {
            if (CargoWeightKg + weight > MaximumLoadCapacity)
            {
                throw new OverfillException("Too much weight in container");
            }
            CargoWeightKg += weight;
        }

        public void WriteInfo()
        {
            Console.WriteLine("Container Information:");
            Console.WriteLine($"Serial Number: {SerialNumber}");
            Console.WriteLine($"Height: {HeightCm} cm");
            Console.WriteLine($"Depth: {DepthCm} cm");
            Console.WriteLine($"Empty Weight: {EmptyWeightKg} kg");
            Console.WriteLine($"Cargo Weight: {CargoWeightKg} kg");
            Console.WriteLine($"Maximum Load Capacity: {MaximumLoadCapacity} kg");
        }

        public abstract string GenerateSerialNumber();
    }
}