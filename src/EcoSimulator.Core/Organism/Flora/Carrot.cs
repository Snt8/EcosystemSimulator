using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism.OrganismDataConfig;

namespace EcoSimulator.Core.Organism;


public class Carrot : FloraOrganism, IGrow, IDie
{
    
    public Carrot(FloraConfig floraConfig) : base(floraConfig.Energy, floraConfig.EnergyGiven, floraConfig.HungryMinus)
    {
        
    }

    public void Grow()
    {
        //Adding the Grow method for delete a Carrot when lives a lot of time
        Age++;
    }

    public void Die()
    {
        //Implements the Die method to see if our carrot has been eaten
        if(!IsEaten && Age <= 3) return;

        IsDead = true;
    }
}