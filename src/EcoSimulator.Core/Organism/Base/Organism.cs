namespace EcoSimulator.Core.Organism.Base;

public abstract class Organism
{
    //Define the base atributes that every animal have
    public double Energy {get; protected set;}
    public int Age {get; protected set;}
    public double PositionX {get; protected set;}
    public double PositionY {get; protected set;}
    public bool IsDead {get; protected set;}

    public Organism(double objEnergy)
    {
        //Base constuction for the atributes
        Energy = objEnergy;
        Age = 0;
        PositionX = 0.0;
        PositionY = 0.0;
        IsDead = false;
    }
}