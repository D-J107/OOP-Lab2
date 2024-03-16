using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class CoolingSystem : PcComponent
{
    private string[] _supportedCpuSockets;

    public CoolingSystem(string name, Dimensions fanDimensions, string[] supportedSockets, int limitOfTdpDispersion)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Graphic card must have a name!");
        if (supportedSockets == null || supportedSockets.Length == 0)
            throw new ArgumentException("Cooling system must have at least one supported socket!");
        if (limitOfTdpDispersion <= 0) throw new ArgumentException("Limit of TDP dispersion must be positive value!");
        Name = name;
        Dimension = fanDimensions;
        _supportedCpuSockets = supportedSockets;
        TdpDispersionLimit = limitOfTdpDispersion;
    }

    public IReadOnlyCollection<string> SupportedCpuSockets => _supportedCpuSockets;
    public int TdpDispersionLimit { get; private set; }
    public Dimensions Dimension { get; private set; }
    public override string Name { get; }
}