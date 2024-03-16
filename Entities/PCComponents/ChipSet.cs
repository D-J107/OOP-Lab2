using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class ChipSet
{
    private bool _hasXmpSupport;

    public ChipSet(int minimumSupportedFrequency, int maximumSupportedFrequency, bool hasXmpSupport)
    {
        if (minimumSupportedFrequency <= 0) throw new ArgumentException("Minimum supported frequency must be positive value!");
        if (maximumSupportedFrequency <= 0) throw new ArgumentException("Maximum supported frequency must be positive value!");
        if (minimumSupportedFrequency > maximumSupportedFrequency)
            throw new ArgumentException("Maximum supported frequency must be grater than minimum supported frequency!");
        MinimumSupportedFrequency = minimumSupportedFrequency;
        MaximumSupportedFrequency = maximumSupportedFrequency;
        _hasXmpSupport = hasXmpSupport;
    }

    public int MinimumSupportedFrequency { get; private set; }
    public int MaximumSupportedFrequency { get; private set; }
}