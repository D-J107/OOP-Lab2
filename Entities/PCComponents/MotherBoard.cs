using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class MotherBoard : PcComponent
{
    private int _pcieLinesAmount;
    private int _sataPortsAmount;
    private ChipSet _chipSet;
    private int _ramSlotsAmount;
    private Bios _bios;

    public MotherBoard(string name, Socket socketForCpu, int pcieLinesAmount, int sataPortsAmount, ChipSet chipSet, string ddrStandard, bool hasBuiltInWifiModule, int ramSlotsAmount, FormFactor formFactor, Bios bios)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Mother board must have a name!");
        if (pcieLinesAmount <= 0) throw new ArgumentException("PCI-E lines amount must be positive value!");
        if (sataPortsAmount <= 0) throw new ArgumentException("SATA ports amount must be positive value!");
        if (string.IsNullOrEmpty(ddrStandard)) throw new ArgumentException("Mother board must have a DDR standard!");
        if (ramSlotsAmount <= 0) throw new ArgumentException("RAM slots amount must be positive value!");
        if (formFactor == FormFactor.None) throw new ArgumentException("Mother board form factor must be known!");
        Name = name;
        SocketForCpu = socketForCpu;
        _pcieLinesAmount = pcieLinesAmount;
        _sataPortsAmount = sataPortsAmount;
        _chipSet = chipSet;
        DdrStandard = ddrStandard;
        HasBuiltInWifiModule = hasBuiltInWifiModule;
        _ramSlotsAmount = ramSlotsAmount;
        FormFactor = formFactor;
        _bios = bios;
    }

    public override string Name { get; }

    public Socket SocketForCpu { get; }

    public string DdrStandard { get; }
    public FormFactor FormFactor { get; }
    public bool HasBuiltInWifiModule { get; }

    public bool CheckCompabilityWithSocketUsingBios(Cpu cpu)
    {
        return _bios.CheckCompabilityWithCpu(cpu);
    }
}