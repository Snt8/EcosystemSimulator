namespace EcoSimulator.Core.Organism.Base;

using System;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.OrganismDataConfig;

public abstract class FaunaOrganism : Organism, IGrow, ICheckMetabolism, IEat, IReproduce, IDie
{
    protected readonly FaunaConfig _config;
    public bool HasEaten {get; protected set;}
    public double Hunger {get; protected set;}
    public double ReproduceEnergy {get; protected set;}

    public FaunaOrganism(FaunaConfig objConfig, double objEnergy, double objReproduceEnergy) : base(objEnergy)
    {
        _config = objConfig;
        HasEaten = false;
        Hunger = 0.0;
        ReproduceEnergy = objReproduceEnergy;
    }

    public virtual void Grow()
    {
        if(IsDead) return;

        Age++;
        CheckMetabolism();
    }

    public virtual void CheckMetabolism()
    {
        //Check if the Organism is younger of 
        double energyCost = (Age < _config.AdultAge) ? _config.EnergySpentYounger : _config.EnergySpentOlder;
        ApplyMetabolism(energyCost, energyCost);
    }

    public virtual void Eat(Organism food)
    {
        // Base logic: Dead animals cannot eat
        if (IsDead) return;
    }

    public void ApplyMetabolism(double energySpent, double hungryGain)
    {
        //Method implements the general rule in the calculation of the Metabolism
        Energy = Math.Max(0, Energy - energySpent);
        Hunger += hungryGain;
    }

    public void Reproduce()
    {
        //Standart form of Reproduce method
        HasEaten = false;
    }

    public void Die()
    {
        //Standart form of Die method
        if((Energy < _config.MinimumEnergy) || (Age > _config.MaxOlderAge))
        {
            IsDead = true;
        }
    }

}