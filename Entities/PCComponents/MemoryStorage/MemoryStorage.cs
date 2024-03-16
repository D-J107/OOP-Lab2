using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents.MemoryStorage;

public abstract class MemoryStorage : PcComponent
{
    private int _memoryCapacity;
    private int _workSpeed;

    protected MemoryStorage(string name, int memoryCapacity, int workSpeed, int powerConsumption)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Graphic card must have a name!");
        if (memoryCapacity <= 0) throw new ArgumentException("Memory capacity must be positive value!");
        if (workSpeed <= 0) throw new ArgumentException("Work speed must be positive value!");
        if (powerConsumption <= 0) throw new ArgumentException("Power consumption must be positive value!");
        Name = name;
        _memoryCapacity = memoryCapacity;
        _workSpeed = workSpeed;
        PowerConsumption = powerConsumption;
    }

    public int PowerConsumption { get; }
    public override string Name { get; }
}