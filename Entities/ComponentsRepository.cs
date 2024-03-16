using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents.MemoryStorage;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComponentsRepository
{
    private Repository<MotherBoard> _motherBoardRepository;
    private Repository<Cpu> _cpuRepository;
    private Repository<Ram> _ramRepository;
    private Repository<GraphicCard> _graphicCardRepository;
    private Repository<CoolingSystem> _coolingSystemRepository;
    private Repository<Corpus> _corpusRepository;
    private Repository<MemoryStorage> _memoryStorageRepository;
    private Repository<PowerSupply> _powerSupplyRepository;
    private Repository<WifiAdapter> _wifiAdapterRepository;

    public ComponentsRepository()
    {
        _motherBoardRepository = new Repository<MotherBoard>();
        _cpuRepository = new Repository<Cpu>();
        _ramRepository = new Repository<Ram>();
        _graphicCardRepository = new Repository<GraphicCard>();
        _coolingSystemRepository = new Repository<CoolingSystem>();
        _corpusRepository = new Repository<Corpus>();
        _memoryStorageRepository = new Repository<MemoryStorage>();
        _powerSupplyRepository = new Repository<PowerSupply>();
        _wifiAdapterRepository = new Repository<WifiAdapter>();
    }

    public IReadOnlyCollection<MotherBoard> MotherBoards => _motherBoardRepository.Components;
    public IReadOnlyCollection<Cpu> Cpus => _cpuRepository.Components;
    public IReadOnlyCollection<Ram> Rams => _ramRepository.Components;
    public IReadOnlyCollection<GraphicCard> GraphicCards => _graphicCardRepository.Components;
    public IReadOnlyCollection<CoolingSystem> CoolingSystems => _coolingSystemRepository.Components;
    public IReadOnlyCollection<Corpus> CorpusCollection => _corpusRepository.Components;
    public IReadOnlyCollection<MemoryStorage?> MemoryStorages => _memoryStorageRepository.Components;
    public IReadOnlyCollection<PowerSupply> PowerSupplies => _powerSupplyRepository.Components;
    public IReadOnlyCollection<WifiAdapter> WifiAdapters => _wifiAdapterRepository.Components;

    public void AddMotherBoardComponent(MotherBoard component)
    {
        _motherBoardRepository.Add(component);
    }

    public void AddCpuComponent(Cpu component)
    {
        _cpuRepository.Add(component);
    }

    public void AddRamComponent(Ram component)
    {
        _ramRepository.Add(component);
    }

    public void AddGraphicCardComponent(GraphicCard component)
    {
        _graphicCardRepository.Add(component);
    }

    public void AddCoolingSystemComponent(CoolingSystem component)
    {
        _coolingSystemRepository.Add(component);
    }

    public void AddCorpusComponent(Corpus component)
    {
        _corpusRepository.Add(component);
    }

    public void AddMemoryStorageComponent(MemoryStorage component)
    {
        _memoryStorageRepository.Add(component);
    }

    public void AddPowerSupplyComponent(PowerSupply component)
    {
        _powerSupplyRepository.Add(component);
    }

    public void AddWifiAdapterComponent(WifiAdapter component)
    {
        _wifiAdapterRepository.Add(component);
    }

    public MotherBoard? FindMotherBoard(string name) => _motherBoardRepository.FindComponentByName(name);
    public Cpu? FindCpu(string name) => _cpuRepository.FindComponentByName(name);
    public Ram? FindRam(string name) => _ramRepository.FindComponentByName(name);
    public GraphicCard? FindGraphicCard(string name) => _graphicCardRepository.FindComponentByName(name);
    public CoolingSystem? FindCoolingSystem(string name) => _coolingSystemRepository.FindComponentByName(name);
    public Corpus? FindCorpus(string name) => _corpusRepository.FindComponentByName(name);
    public MemoryStorage? FindMemoryStorage(string name) => _memoryStorageRepository.FindComponentByName(name);
    public PowerSupply? FindPowerSupply(string name) => _powerSupplyRepository.FindComponentByName(name);
    public WifiAdapter? FindWifiAdapter(string name) => _wifiAdapterRepository.FindComponentByName(name);
}