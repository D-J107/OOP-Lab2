using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CustomExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents.MemoryStorage;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CompabilityCheckResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public sealed class PcConfigurator
{
    private MotherBoard? _motherBoard;
    private Cpu? _cpu;
    private CoolingSystem? _coolingSystem;
    private Ram? _ram;
    private GraphicCard? _graphicCard;
    private MemoryStorage? _memoryStorage;
    private Corpus? _corpus;
    private PowerSupply? _powerSupply;
    private WifiAdapter? _wifiAdapter;

    public PcConfigurator SetMotherBoard(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public PcConfigurator SetCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public PcConfigurator SetCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public PcConfigurator SetRam(Ram ram)
    {
        _ram = ram;
        return this;
    }

    public PcConfigurator SetGraphicCard(GraphicCard graphicCard)
    {
        _graphicCard = graphicCard;
        return this;
    }

    public PcConfigurator SetMemoryStorage(MemoryStorage memoryStorage)
    {
        _memoryStorage = memoryStorage;
        return this;
    }

    public PcConfigurator SetCorpus(Corpus corpus)
    {
        _corpus = corpus;
        return this;
    }

    public PcConfigurator SetPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public PcConfigurator SetWifiAdapter(WifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public CheckResult Validate()
    {
        var validator = new
            Validator(_motherBoard, _cpu, _coolingSystem, _ram, _graphicCard, _memoryStorage, _corpus, _powerSupply, _wifiAdapter);

        return validator.Valid();
    }

    public Pc Build()
    {
        if (_motherBoard == null) throw new AttributeNotSpecifiedException(nameof(_motherBoard));
        if (_cpu == null) throw new AttributeNotSpecifiedException(nameof(_cpu));
        if (_coolingSystem == null) throw new AttributeNotSpecifiedException(nameof(_coolingSystem));
        if (_ram == null) throw new AttributeNotSpecifiedException(nameof(_ram));
        if (_memoryStorage == null) throw new AttributeNotSpecifiedException(nameof(_memoryStorage));
        if (_corpus == null) throw new AttributeNotSpecifiedException(nameof(_corpus));
        if (_powerSupply == null) throw new AttributeNotSpecifiedException(nameof(_powerSupply));

        var validator = new
            Validator(_motherBoard, _cpu, _coolingSystem, _ram, _graphicCard, _memoryStorage, _corpus, _powerSupply, _wifiAdapter);

        CheckResult result = validator.Valid();
        if (result is InvalidConfiguration) throw new ArgumentException("Error! some PC components not compatible!");

        return new Pc(
            _motherBoard,
            _cpu,
            _coolingSystem,
            _ram,
            _graphicCard,
            _memoryStorage,
            _corpus,
            _powerSupply,
            _wifiAdapter);
    }
}