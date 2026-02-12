using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism.OrganismDataConfig;

namespace EcoSimulator.Core.Organism;


public class Carrot : FloraOrganism, IGrow, IDie
{
    
    public Carrot(FloraConfig floraConfig) : base(floraConfig.Energy, floraConfig.EnergyGiven, floraConfig.HungryMinus, floraConfig.MaxFloraAge)
    {
        
    }
}