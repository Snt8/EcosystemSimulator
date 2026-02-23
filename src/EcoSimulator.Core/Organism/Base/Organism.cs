namespace EcoSimulator.Core.Organism.Base;

public abstract class Organism
{
    //Define the base atributes that every Organism has
    public double Energy {get; protected set;}
    public int Age {get; protected set;}
    public bool IsDead {get; protected set;}
    public bool IsEaten {get; set;}

    public Organism(double objEnergy)
    {
        //Base constuction for the atributes
        Energy = objEnergy;
        Age = 0;
        IsDead = false;
        IsEaten = false;
    }
}