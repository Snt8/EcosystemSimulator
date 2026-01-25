using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism.OrganismDataConfig;

namespace EcoSimulator.Core.Organism;


public class Carrot : FloraOrganism, IDie
{
    
    public Carrot(FloraConfig floraConfig) : base(floraConfig.Energy, floraConfig.EnergyGiven, floraConfig.HungryMinus)
    {
        
    }

    public void Die()
    {
        //Implements the Die method to see if our carrot has been eaten
        if(!IsEaten) return;

        IsDead = true;
    }
}