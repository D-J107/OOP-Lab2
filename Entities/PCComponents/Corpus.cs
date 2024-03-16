using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

public sealed class Corpus : PcComponent
{
    private FormFactor[] _supportedMotherBoardFormFactors;

    public Corpus(string name, int graphicCardLenghtLimit, int graphicCardWeightLimit, FormFactor[] supportedMotherBoardFormFactors, Dimensions dimensions)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Graphic card must have a name!");
        if (graphicCardLenghtLimit <= 0) throw new ArgumentException("Limit of graphic card lenght must be positive value!");
        if (graphicCardWeightLimit <= 0) throw new ArgumentException("Limit of graphic card weight must be positive value!");
        if (supportedMotherBoardFormFactors == null || supportedMotherBoardFormFactors.Length == 0)
            throw new ArgumentException("Corpus must supports at least one mother board form factor!");
        Name = name;
        GraphicCardLenghtLimit = graphicCardLenghtLimit;
        GraphicCardWeightLimit = graphicCardWeightLimit;
        _supportedMotherBoardFormFactors = supportedMotherBoardFormFactors;
        Dimensions = dimensions;
    }

    public int GraphicCardLenghtLimit { get; private set; }
    public int GraphicCardWeightLimit { get; private set; }
    public IReadOnlyCollection<FormFactor> SupportedMotherBoardFormFactors => _supportedMotherBoardFormFactors;

    public Dimensions Dimensions { get; }
    public override string Name { get; }
}