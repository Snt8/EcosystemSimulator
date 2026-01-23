namespace EcoSimulator.Core.Processors;

using System.Linq;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism;
using EcoSimulator.Core.Organism.Base;

public class RabbitProcessor : ILifeFaunaProcessor
{
    //Local Processor calls the rabbits methods
    public void CallGrow(IEnumerable<IGrow> rabbits)
    {
        //Calling the Grow method
        foreach(var rabbit in rabbits)
        {
            rabbit.Grow();
        }
    }

    public IEnumerable<FloraOrganism> CallEat(IEnumerable<IEat> rabbits, IEnumerable<FloraOrganism> food)
    {
        List<FloraOrganism> eatenFood = new();
        foreach(var rabbit in rabbits)
        {
            var targetFood = food.FirstOrDefault(f => !f.IsEaten);
            //Checking about if the targetFood could be null
            if(targetFood is not null)
            {
                //Calling the Eat() method and adding the target in the List that return the food have eaten
                rabbit.Eat(targetFood);
                targetFood.IsEaten = true;
                eatenFood.Add(targetFood);
            }

        }

        return eatenFood;
    }

    public IEnumerable<FaunaOrganism> CallDie(IEnumerable<IDie> organism)
    {
        List<FaunaOrganism> diedRabbits = new();
        foreach(var rabbit in organism)
        {
            rabbit.Die();

            if(rabbit is FaunaOrganism fauna && fauna.IsDead)
            {
                diedRabbits.Add(fauna);
            }
        }

        return diedRabbits;
    }
}
