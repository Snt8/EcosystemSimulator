namespace EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Interface.IOrganism;

public abstract class FloraOrganism : Organism, IGrow, IDie
{
    public double EnergyGiven {get; protected set;} //Energy FloraOrganism gives to an animal
    public double HungryMinus {get; protected set;} //Hungry FloraOrganism minus to an animal
    public int MaxAge {get; protected set;} //The max time that the FloraOrganism can exist

    public FloraOrganism(double objEnergyGiven, double objHungryMinus, int objMaxAge)
    {
        //Constructor with the base atributes
        EnergyGiven = objEnergyGiven;
        HungryMinus = objHungryMinus;
        MaxAge = objMaxAge;
    
    }

    public virtual void Grow()
    {
        //Check if the organism is dead
        if(IsDead) return;
        Age++;
    }

    public virtual void Die()
    {
        //Checks if the FloraOrganism hasn't been consumed and if is younger than the MaxAge
        if(!IsEaten && Age <= MaxAge) return;
        
        IsDead = true;
    }
}