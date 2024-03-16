namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public sealed record Timings()
{
    public Timings(int casLatency, int rasToCasDelay, int rowPreChargeDelay, int activateToPreChargeDelay)
        : this()
    {
        CasLatency = casLatency;
        RasToCasDelay = rasToCasDelay;
        RowPreChargeDelay = rowPreChargeDelay;
        ActivateToPreChargeDelay = activateToPreChargeDelay;
    }

    public int CasLatency { get; }
    public int RasToCasDelay { get; }
    public int RowPreChargeDelay { get; }
    public int ActivateToPreChargeDelay { get; }
}