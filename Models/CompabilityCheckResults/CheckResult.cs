namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CompabilityCheckResults;

public abstract class CheckResult
{
    protected CheckResult(string information)
    {
        Information = information;
    }

    public string Information { get; private set; }
}