using EcoSimulator.Core.Organisms.OrganismDataConfig.General;

namespace EcoSimulator.Core.Organisms.OrganismDataConfig.Specific;


public class FloraConfig : OrganismConfig
{
    //Standard Initial Configuration for every FloraOrganism
    public double EnergyGiven{get; set;}
    public double HungryMinus{get; set;}
    public int MaxFloraAge{get; set;}
}