using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism.OrganismDataConfig;

namespace EcoSimulator.Core.Organism;


public sealed class Carrot : FloraOrganism
{
    
    public Carrot(FloraConfig floraConfig) : base(floraConfig.Energy, floraConfig.EnergyGiven, floraConfig.HungryMinus, floraConfig.MaxFloraAge)
    {
        
    }
}