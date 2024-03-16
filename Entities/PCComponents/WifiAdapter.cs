using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class WifiAdapter : PcComponent
{
    private string _standardVersion;
    private bool _hasBuiltInBluetoothModule;
    private string _pCIeVersion;

    public WifiAdapter(string name, string standardVersion, bool hasBuiltInBluetoothModule, string pCIeVersion, int powerConsumption)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Wifi adapter must have a name!");
        if (string.IsNullOrEmpty(standardVersion)) throw new ArgumentException("Wifi adapter must have a standard version!");
        if (string.IsNullOrEmpty(pCIeVersion)) throw new ArgumentException("Wifi adapter must have a PCI version!");
        if (powerConsumption <= 0) throw new ArgumentException("Power consumption value must be positive!");
        Name = name;
        _standardVersion = standardVersion;
        _hasBuiltInBluetoothModule = hasBuiltInBluetoothModule;
        _pCIeVersion = pCIeVersion;
        PowerConsumption = powerConsumption;
    }

    public int PowerConsumption { get; }
    public override string Name { get; }
}