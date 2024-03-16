namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CompabilityCheckResults;

public sealed class InvalidConfiguration : CheckResult
{
    public InvalidConfiguration(string information)
        : base(information)
    { }
}