using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents.MemoryStorage;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.CompabilityCheckResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public sealed class Validator
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

    public Validator(MotherBoard? motherBoard, Cpu? cpu, CoolingSystem? coolingSystem, Ram? ram, GraphicCard? graphicCard, MemoryStorage? memoryStorage, Corpus? corpus, PowerSupply? powerSupply, WifiAdapter? wifiAdapter)
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

    public CheckResult Valid()
    {
        if (_motherBoard == null) return new AttributeNotSpecified("Mother board is not specified!");
        if (_cpu == null) return new AttributeNotSpecified("CPU is not specified!");
        if (_coolingSystem == null) return new AttributeNotSpecified("Cooling system is not specified!");
        if (_ram == null) return new AttributeNotSpecified("RAM is not specified!");
        if (_memoryStorage == null) return new AttributeNotSpecified("Memory storage is not specified!");
        if (_corpus == null) return new AttributeNotSpecified("Corpus is not specified!");
        if (_powerSupply == null) return new AttributeNotSpecified("Power supply unit is not specified!");

        if (!CheckCpuCompability())
        {
            return new InvalidConfiguration("Cpu is not compatible!");
        }

        if (!CheckCoolingSystemBaseCompability())
        {
            return new InvalidConfiguration("Cooling system is not compatible!");
        }

        if (!CheckCoolingSystemOptimalHeadDissipation())
        {
            return new DisclaimerOfWarranty("Warning! Cooling system power maybe not enough!");
        }

        if (!CheckRamCompability())
        {
            return new InvalidConfiguration("RAM is not compatible!");
        }

        if (!CheckGraphicImageOutputAbility())
        {
            return new InvalidConfiguration("Configuration does not have graphic output device!");
        }

        if (!CheckMemoryStorageHaving())
        {
            return new InvalidConfiguration("Configuration does not have memory storage!");
        }

        if (!CheckCorpusContainAbility())
        {
            return new InvalidConfiguration("Corpus cant contain all components!");
        }

        if (!CheckPowerSupplyUnitBaseAbility())
        {
            return new InvalidConfiguration("Power supply is insufficient!");
        }

        if (!CheckPowerSupplyUnitOptimalAbility())
        {
            return new DisclaimerOfWarranty("Warning! Power supply unit energy maybe not enough!");
        }

        if (!CheckNetworkEquipmentConflictResolution())
        {
            return new InvalidConfiguration("Wifi module compability is broken with current mother board!");
        }

        return new Success();
    }

    private bool CheckCpuCompability()
    {
        if (_motherBoard == null || _cpu == null) return false;
        return (_motherBoard.SocketForCpu == _cpu.Socket) && _motherBoard.CheckCompabilityWithSocketUsingBios(_cpu);
    }

    private bool CheckCoolingSystemBaseCompability()
    {
        if (_coolingSystem == null || _cpu == null) return false;
        return _coolingSystem.SupportedCpuSockets.Any(socketName => _cpu.Socket.Name == socketName);
    }

    private bool CheckCoolingSystemOptimalHeadDissipation()
    {
        if (_coolingSystem == null || _cpu == null) return false;
        return _coolingSystem.TdpDispersionLimit >= _cpu.Tdp;
    }

    private bool CheckRamCompability()
    {
        if (_ram == null || _motherBoard == null || _cpu == null) return false;
        bool ddrCompability = _ram.DdrStandard == _motherBoard.DdrStandard;
        return ddrCompability && _cpu.SupportedMemoryFrequencies.Any(frequency =>
            _ram.MainWorkFrequency == frequency);
    }

    private bool CheckGraphicImageOutputAbility()
    {
        if (_cpu == null) return false;
        if (_cpu.HasBuiltInGraphicCore) return true;
        if (_graphicCard == null) return false;
        return _cpu.SupportedMemoryFrequencies.Any(frequency => _graphicCard.ChipFrequency == frequency);
    }

    private bool CheckMemoryStorageHaving()
    {
        return _memoryStorage != null;
    }

    private bool CheckCorpusContainAbility()
    {
        if (_corpus == null || _motherBoard == null || _coolingSystem == null || _powerSupply == null) return false;
        if (_graphicCard != null && (_graphicCard.Dimensions.Lenght > _corpus.GraphicCardLenghtLimit ||
                                     _graphicCard.Dimensions.Width > _corpus.GraphicCardWeightLimit)) return false;
        if (_corpus.SupportedMotherBoardFormFactors.All(formFactor => _motherBoard.FormFactor != formFactor))
            return false;
        var maximumOfAllDimensions = Dimensions.Maximum(new Dimensions[]
        {
            _coolingSystem.Dimension,
            _powerSupply.Dimensions,
            (_graphicCard?.Dimensions ?? new Dimensions()),
        });

        return maximumOfAllDimensions.LessInAllDirectionsThan(_corpus.Dimensions);
    }

    private bool CheckPowerSupplyUnitBaseAbility()
    {
        if (_powerSupply == null || _cpu == null || _ram == null || _memoryStorage == null) return false;
        int totalElectricalSupply = _cpu.PowerConsumption + _ram.PowerConsumption + _memoryStorage.PowerConsumption +
                                    (_graphicCard?.PowerConsumption ?? 0) + (_wifiAdapter?.PowerConsumption ?? 0);
        return _powerSupply.LimitOfElectricalSupply >= totalElectricalSupply;
    }

    private bool CheckPowerSupplyUnitOptimalAbility()
    {
        if (_powerSupply == null || _cpu == null || _ram == null || _memoryStorage == null) return false;
        int totalElectricalSupply = _cpu.PowerConsumption + _ram.PowerConsumption + _memoryStorage.PowerConsumption +
                                    (_graphicCard?.PowerConsumption ?? 0) + (_wifiAdapter?.PowerConsumption ?? 0);
        return _powerSupply.RecommendedElectricalSupply >= totalElectricalSupply;
    }

    private bool CheckNetworkEquipmentConflictResolution()
    {
        if (_motherBoard == null) return false;
        return !(_motherBoard.HasBuiltInWifiModule && _wifiAdapter != null);
    }
}