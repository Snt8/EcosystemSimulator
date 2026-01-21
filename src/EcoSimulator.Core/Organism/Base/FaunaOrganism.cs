namespace EcoSimulator.Core.Organism.Base;

using System.Runtime.CompilerServices;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.IOrganism;

public abstract class FaunaOrganism : Organism
{
    public bool IsEaten {get; protected set;}
    public double Hunger {get; protected set;}

    public FaunaOrganism(double objEnergy) : base(objEnergy)
    {
        IsEaten = false;
        Hunger = 0.0;
    }

    protected void ApplyMetabolism(double energySpent, double hungryGain)
    {
        //Method implements the general rule in the calculation of the Metabolism
        Energy = Math.Max(0, Energy - energySpent);
        Hunger += hungryGain;
    }

}