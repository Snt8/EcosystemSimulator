namespace EcoSimulator.Core.Organism.Base;

public abstract class FloraOrganism : Organism
{
    public double EnergyGiven {get; protected set;} //Energy FloraOrganism gives to an animal
    public double HungryMinus {get; protected set;} //Hungry FloraOrganism minus to an animal
    public bool IsEaten {get; set;} //Flag for check if the FloraOrganism instance have eaten by a FaunaOrganism

    public FloraOrganism(double objEnergy, double objEnergyGiven, double objHungryMinus) : base(objEnergy)
    {
        //Constructor with the base atributes
        EnergyGiven = objEnergyGiven;
        HungryMinus = objHungryMinus;
        IsEaten = false;
    }
}