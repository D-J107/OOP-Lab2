using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class GraphicCard : PcComponent
{
    private int _videoMemoryAmount;

    public GraphicCard(string name, Dimensions dimensions, int videoMemoryAmount, string pCIeVersion, int chipFrequency, int powerConsumption)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Graphic card must have a name!");
        if (videoMemoryAmount <= 0) throw new ArgumentException("Video memory amount must be positive value!");
        if (string.IsNullOrEmpty(pCIeVersion)) throw new ArgumentException("Graphic card must have a PCI-E version!");
        if (chipFrequency <= 0) throw new ArgumentException("Chip frequency must be positive value!");
        if (powerConsumption <= 0) throw new ArgumentException("Power consumption must be positive value!");
        Name = name;
        Dimensions = dimensions;
        _videoMemoryAmount = videoMemoryAmount;
        PcieVersion = pCIeVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string PcieVersion { get; private set; }

    public int ChipFrequency { get; private set; }

    public int PowerConsumption { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public override string Name { get; }
}