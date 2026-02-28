namespace EcoSimulator.Core.Organisms.Base;

public abstract class Organism
{
    //Define the base atributes that every Organism has
    public int Age {get; protected set;}
    public bool IsDead {get; protected set;}
    public bool IsEaten {get; set;}

    public Organism()
    {
        //Base constuction for the atributes
        Age = 0;
        IsDead = false;
        IsEaten = false;
    }
}