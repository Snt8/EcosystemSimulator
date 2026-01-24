namespace EcoSimulator.Core.Processors;

using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism;
using EcoSimulator.Core.Organism.Base;

public class RabbitProcessor : ILifeFaunaProcessor
{
    public List<Organism> MasterRabbit {get; private set;}
    public List<FloraOrganism> MasterFood {get; private set;}
    private Queue<FloraOrganism> UneatenFood {get; set;}
    public RabbitProcessor(List<Organism> objMasterRabbits, List<FloraOrganism> objMasterFood)
    {
        MasterRabbit = objMasterRabbits;
        MasterFood = objMasterFood;
        UneatenFood = new Queue<FloraOrganism>(MasterFood.Where(f => !f.IsEaten));
    }
    
    //Local Processor calls the rabbits methods
    public void CallGrow()
    {
        //Calling the Grow method
        foreach(var rabbit in MasterRabbit.OfType<IGrow>())
        {
            rabbit.Grow();
        }
    }

    public IEnumerable<FloraOrganism> CallEat()
    {
        List<FloraOrganism> eatenFood = new();
        foreach(var rabbit in MasterRabbit.OfType<IEat>())
        {
            //Using the internal Queue for O(1) access
            if(UneatenFood.TryDequeue(out var targetFood))
            {
                //Calling the Eat() method and adding the target in the List that return the food have eaten
                rabbit.Eat(targetFood);
                targetFood.IsEaten = true;
                eatenFood.Add(targetFood);
            }

        }

        return eatenFood;
    }

    public IEnumerable<Organism> CallDie()
    {
        List<Organism> diedRabbits = new();
        foreach(var rabbit in MasterRabbit.OfType<IDie>())
        {
            rabbit.Die();

            //Checking if our rabbit die
            if(rabbit is Organism fauna && fauna.IsDead)
            {
                diedRabbits.Add(fauna);
            }
        }

        return diedRabbits;
    }
}
