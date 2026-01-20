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

    public virtual void ResetHunger(double energyGiven)
    {
        Hunger = Math.Max(0, Hunger - energyGiven);
    }
}