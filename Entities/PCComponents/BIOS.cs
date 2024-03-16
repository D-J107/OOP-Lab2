using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class Bios
{
    private string _type;
    private string _version;
    private string[] _suppotedCpus;

    public Bios(string type, string version, string[] supportedCpUs)
    {
        if (string.IsNullOrEmpty(type)) throw new ArgumentException("Bios type must be known!");
        if (string.IsNullOrEmpty(version)) throw new ArgumentException("Bios version must be known!");
        if (supportedCpUs == null || supportedCpUs.Length == 0) throw new ArgumentException("Bios must support at least one CPU!");
        _type = type;
        _version = version;
        _suppotedCpus = supportedCpUs;
    }

    public bool CheckCompabilityWithCpu(Cpu cpu)
    {
        if (cpu is null) return false;
        return _suppotedCpus.Any(currentCpuName => cpu.Name == currentCpuName);
    }
}