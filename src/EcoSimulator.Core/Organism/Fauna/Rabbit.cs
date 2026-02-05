namespace EcoSimulator.Core.Organism;

using System;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism.OrganismDataConfig;



public class Rabbit : FaunaOrganism, IGrow, ICheckMetabolism, IEat, IReproduce, IDie
{
    public Rabbit(FaunaConfig config) : base(config, config.MaxEnergy, config.FaunaReproduceEnergy)
    {
    }

    public override void Eat(Organism food)
    {
        // Call base to check common rules (like IsDead)
        base.Eat(food);
        
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