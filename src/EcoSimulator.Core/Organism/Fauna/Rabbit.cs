namespace EcoSimulator.Core.Organism;

using System;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism.OrganismDataConfig;



public class Rabbit : FaunaOrganism, IGrow, ICheckMetabolism, IEat, IReproduce, IDie
{
    private readonly FaunaConfig _config;

    public Rabbit(FaunaConfig config) : base(config.MaxEnergy, config.FaunaReproduceEnergy)
    {
        _config = config;
    }

    public void Grow()
    {
        if (IsDead) return;
        //Grow process: The rabbit increment 1 year per call, check Energy Spent.
        Age ++;
        CheckMetabolism();
    }

    public void CheckMetabolism()
    {
        //Calculated the Energy Spent and the Hunger of the rabbit
        double energyCost = (Age < _config.AdultAge) ? _config.EnergySpentYounger : _config.EnergySpentOlder;
        ApplyMetabolism(energyCost, energyCost);
    }

    public void Eat(Organism food)
    {
        if(IsDead) return;
        
        if (food is FloraOrganism flora && !flora.IsEaten && !flora.IsDead)
        {
            //The rabbit eat his food and give Energy and minus Hungry
            Energy = Math.Min(Energy + flora.EnergyGiven, _config.MaxEnergy);
            Hunger = Math.Max(Hunger - flora.HungryMinus, 0);
            HasEaten = true;
            flora.IsEaten = true;
        }
    }

    public void Reproduce()
    {
        HasEaten = false;
    }

    public void Die()
    {
        //The rabbit die if is older than 12 or his energy is minus than 5.0
        if((Energy < _config.MinimumEnergy) || (Age > _config.MaxOlderAge))
        {
            IsDead = true;
        }
    }

}