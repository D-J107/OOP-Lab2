using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class Cpu : PcComponent
{
    private int _coreFrequency;
    private int _coresAmount;
    private int[] _supportedMemoryFrequencies;

    public Cpu(string name, int coreFrequency, int coresAmount, Socket socket, bool hasBuiltInGraphicsCore, int[] supportedMemoryFrequencies, int tDp, int powerConsumption)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Graphic card must have a name!");
        if (coreFrequency <= 0) throw new ArgumentException("Core frequency must be positive value!");
        if (coresAmount <= 0) throw new ArgumentException("Cores amount must be positive value!");
        if (supportedMemoryFrequencies == null || supportedMemoryFrequencies.Length == 0)
            throw new ArgumentException("CPU must support at least one memory frequency!");
        if (tDp <= 0) throw new ArgumentException("TDP must be positive value!");
        if (powerConsumption <= 0) throw new ArgumentException("Power consumption must be positive value!");
        Name = name;
        _coreFrequency = coreFrequency;
        _coresAmount = coresAmount;
        Socket = socket;
        HasBuiltInGraphicCore = hasBuiltInGraphicsCore;
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        Tdp = tDp;
        PowerConsumption = powerConsumption;
    }

    public override string Name { get; }

    public Socket Socket { get; }

    public bool HasBuiltInGraphicCore { get; }

    public IReadOnlyCollection<int> SupportedMemoryFrequencies => _supportedMemoryFrequencies;
    public int Tdp { get; }
    public int PowerConsumption { get; }
}