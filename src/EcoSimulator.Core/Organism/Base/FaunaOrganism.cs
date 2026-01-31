namespace EcoSimulator.Core.Organism.Base;

using System;
using EcoSimulator.Core.Interface.IOrganism;

public abstract class FaunaOrganism : Organism
{
    public bool HasEaten {get; protected set;}
    public double Hunger {get; protected set;}
    public double ReproduceEnergy {get; protected set;}

    public FaunaOrganism(double objEnergy, double objReproduceEnergy) : base(objEnergy)
    {
        HasEaten = false;
        Hunger = 0.0;
        ReproduceEnergy = objReproduceEnergy;
    }

    protected void ApplyMetabolism(double energySpent, double hungryGain)
    {
        //Method implements the general rule in the calculation of the Metabolism
        Energy = Math.Max(0, Energy - energySpent);
        Hunger += hungryGain;
    }

}