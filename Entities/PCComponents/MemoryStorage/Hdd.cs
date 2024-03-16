namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents.MemoryStorage;

public class Hdd : MemoryStorage
{
    public Hdd(string name, int memoryCapacity, int workSpeed, int powerConsumption)
        : base(name, memoryCapacity, workSpeed, powerConsumption)
    { }
}