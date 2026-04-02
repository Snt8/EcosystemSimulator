using EcoSimulator.Core.Organisms.OrganismDataConfig.General;

namespace EcoSimulator.Core.Organisms.OrganismDataConfig.Specific;


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