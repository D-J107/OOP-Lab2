namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents.MemoryStorage;

public class Ssd : MemoryStorage
{
    private string _connectionType;

    public Ssd(string name, int memoryCapacity, int workSpeed, int powerConsumption, string connectionType)
        : base(name, memoryCapacity, workSpeed, powerConsumption)
    {
        _connectionType = connectionType;
    }
}