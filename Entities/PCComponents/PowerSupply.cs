using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class PowerSupply : PcComponent
{
    public PowerSupply(string name, int standardElectricalSupply, int limitOfElectricalSupply, Dimensions dimensions)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Power supply unit must have a name!");
        Name = name;
        if (standardElectricalSupply <= 0) throw new ArgumentException("Electrical supply must be positive value!");
        if (limitOfElectricalSupply <= 0)
            throw new ArgumentException("Limit of electrical supply must be positive value!");
        if (limitOfElectricalSupply <= standardElectricalSupply)
            throw new ArgumentException("Electrical supply limit must be greater than standard supply!");
        RecommendedElectricalSupply = standardElectricalSupply;
        LimitOfElectricalSupply = limitOfElectricalSupply;
        Dimensions = dimensions;
    }

    public int RecommendedElectricalSupply { get; private set; }
    public int LimitOfElectricalSupply { get; private set; }

    public Dimensions Dimensions { get; private set; }
    public override string Name { get; }
}