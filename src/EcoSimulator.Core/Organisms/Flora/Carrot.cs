using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organisms.Base;
using EcoSimulator.Core.Organisms.OrganismDataConfig.Specific;

namespace EcoSimulator.Core.Organism;


public sealed class Carrot : FloraOrganism
{
    
    public Carrot(FloraConfig floraConfig) : base(floraConfig.EnergyGiven, floraConfig.HungryMinus, floraConfig.MaxFloraAge)
    {
        
    }
}