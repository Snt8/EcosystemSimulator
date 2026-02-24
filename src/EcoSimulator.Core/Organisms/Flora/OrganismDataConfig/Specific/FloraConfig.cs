namespace EcoSimulator.Core.Organism.OrganismDataConfig.Specific;

using EcoSimulator.Core.Organism.OrganismDataConfig.General;

public class FloraConfig : OrganismConfig
{
    //Standard Initial Configuration for every FloraOrganism
    public double Energy {get; set;}
    public double EnergyGiven{get; set;}
    public double HungryMinus{get; set;}
    public int MaxFloraAge{get; set;}
}