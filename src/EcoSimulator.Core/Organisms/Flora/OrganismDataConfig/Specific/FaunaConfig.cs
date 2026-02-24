namespace EcoSimulator.Core.Organism.OrganismDataConfig.Specific;

using EcoSimulator.Core.Organism.OrganismDataConfig.General;

public class FaunaConfig : OrganismConfig
{
    //Standard Fauna Organism constant atributes
    public double EnergySpentYounger {get; set;}
    public double EnergySpentOlder {get; set;}
    public int AdultAge {get; set;}
    public int MaxOlderAge {get; set;}
    public double MaxEnergy {get; set;}
    public double MinimumEnergy {get; set;}
    public double FaunaReproduceEnergy {get; set;}
}