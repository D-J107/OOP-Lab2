namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class XmpProfile
{
    private int[] _timings;
    private int _voltage;
    private int _frequency;

    public XmpProfile(int[] timings, int voltage, int frequency)
    {
        _timings = timings;
        _voltage = voltage;
        _frequency = frequency;
    }
}