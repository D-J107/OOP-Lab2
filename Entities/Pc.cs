using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents.MemoryStorage;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public sealed class Pc
{
    private MotherBoard _motherBoard;
    private Cpu _cpu;
    private CoolingSystem _coolingSystem;
    private Ram _ram;
    private GraphicCard? _graphicCard;
    private MemoryStorage _memoryStorage;
    private Corpus _corpus;
    private PowerSupply _powerSupply;
    private WifiAdapter? _wifiAdapter;

    public Pc(MotherBoard motherBoard, Cpu cpu, CoolingSystem coolingSystem, Ram ram, GraphicCard? graphicCard, MemoryStorage memoryStorage, Corpus corpus, PowerSupply powerSupply, WifiAdapter? wifiAdapter)
    {
        _motherBoard = motherBoard;
        _cpu = cpu;
        _coolingSystem = coolingSystem;
        _ram = ram;
        _graphicCard = graphicCard;
        _memoryStorage = memoryStorage;
        _corpus = corpus;
        _powerSupply = powerSupply;
        _wifiAdapter = wifiAdapter;
    }
}