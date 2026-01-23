namespace EcoSimulator.Core.Organism;

using System;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;



public class Rabbit : FaunaOrganism, IGrow, ICheckMetabolism, IEat, IDie
{
    private const double EnergySpentYounger = 10.0;
    private const double EnergySpentOlder = 5.0;
    private const int AdultAge = 6;
    private const int MaxOlderAge = 12;
    private const double MaxRabbitEnergy = 65.0;
    private const double MinimumRabbitEnergy = 3.5;

    public Rabbit() : base(MaxRabbitEnergy)
    {
        
    }

    public void Grow()
    {
        if (IsDead) return;
        //Grow process: The rabbit increment 1 year per call, check him Energy Spent and Check if Die.
        Age ++;
        CheckMetabolism();
        Die();
    }

    public void CheckMetabolism()
    {
        //Calculated the Energy Spent and the Hunger of the rabbit
        double energyCost = (Age < AdultAge) ? EnergySpentYounger : EnergySpentOlder;
        ApplyMetabolism(energyCost, energyCost);
    }

    public void Eat(FloraOrganism food)
    {
        if(IsDead) return;
        //The rabbit eat his food and give Energy and minus Hungry
        Energy = Math.Min(Energy + food.EnergyGiven, MaxRabbitEnergy);
        Hunger = Math.Max(Hunger - food.HungryMinus, 0);
        HasEaten = true;
    } 

    public void Die()
    {
        //The rabbit die if is older than 12 or his energy is minus than 5.0
        if((Energy < MinimumRabbitEnergy) || (Age > MaxOlderAge))
        {
            IsDead = true;
        }
    }

}