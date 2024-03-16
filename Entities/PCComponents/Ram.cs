using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class Ram : PcComponent
{
    private int _memoryAmount;
    private int[] _supportedJedecFrequency;
    private int[] _supportedVoltage;
    private bool _hasXmpProfileSupport;
    private string _formFactor;

    public Ram(string name, int memoryAmount, int mainWorkFrequency, int[] supportedJedecFrequency, int[] supportedVoltage, bool hasXmpProfileSupport, string formFactor, string dDrStandard, int powerConsumption)
    {
        if (memoryAmount <= 0) throw new ArgumentException("Memory amount must be positive value!");
        if (mainWorkFrequency <= 0) throw new ArgumentException("Frequency must be positive value!");
        if (supportedJedecFrequency == null || supportedJedecFrequency.Length == 0)
            throw new ArgumentException("Ram must have at least one supported Jedec frequency!");
        if (supportedVoltage == null || supportedVoltage.Length == 0)
            throw new ArgumentException("Ram must have at least one supported voltage!");
        if (string.IsNullOrEmpty(formFactor)) throw new ArgumentException("RAM form-factor must be known!");
        if (string.IsNullOrEmpty(dDrStandard)) throw new ArgumentException("Ram must have DDR standard!");
        if (powerConsumption <= 0) throw new ArgumentException("Power consumption value must be positive!");
        Name = name;
        _memoryAmount = memoryAmount;
        MainWorkFrequency = mainWorkFrequency;
        _supportedJedecFrequency = supportedJedecFrequency;
        _supportedVoltage = supportedVoltage;
        _hasXmpProfileSupport = hasXmpProfileSupport;
        _formFactor = formFactor;
        DdrStandard = dDrStandard;
        PowerConsumption = powerConsumption;
    }

    public string DdrStandard { get; private set; }
    public int MainWorkFrequency { get; private set; }
    public int PowerConsumption { get; private set; }
    public override string Name { get; }
}