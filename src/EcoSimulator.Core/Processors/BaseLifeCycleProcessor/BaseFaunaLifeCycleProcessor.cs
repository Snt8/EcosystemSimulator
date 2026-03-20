using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using BaseOrganism = EcoSimulator.Core.Organisms.Base.Organism;
using EcoSimulator.Core.Organisms.Base;
using EcoSimulator.Core.Interface;

namespace EcoSimulator.Core.Processors.BaseLifeCycleProcessor;

public class FaunaLifeCycleProcessor : ILifeFaunaProcessor
{
    public List<FaunaOrganism> MasterOrganism {get; private set;}
    public List<BaseOrganism> MasterFoodOrganism {get; private set;}
    public Queue<BaseOrganism> UneatedFood { get; private set; }

    public FaunaLifeCycleProcessor(List<FaunaOrganism> MasterOrgnaism, List<BaseOrganism> MasterFoodOrganism)
    {
        this.MasterOrganism = MasterOrgnaism;
        this.MasterFoodOrganism = MasterFoodOrganism;

        // Inicializamos la cola de alimentos disponibles basándonos en la lista inicial
        this.UneatedFood = new Queue<BaseOrganism>(MasterFoodOrganism.Where(f => !f.IsEaten && f is BaseOrganism));
    }

    public void CallGrow()
    {
        foreach (var organism in MasterOrganism)
        {
            //Calling Organism grow method
            organism.Grow();
        }

    }

    public IEnumerable<BaseOrganism> CallEat()
    {
        //create eaten food list
        List<BaseOrganism> eatenFood = new();
        foreach(var organism in MasterOrganism.OfType<IEat>())
        {
            //Access to UneatedFood
            if(UneatedFood.TryDequeue(out var targetFood))
            {
                //Call Eat() method
                organism.Eat(targetFood);

                if (targetFood.IsEaten)
                {
                    //Add the eatenFood into list
                    eatenFood.Add(targetFood);
                }
            }
        }

        return eatenFood;

    }

    public IEnumerable<BaseOrganism> CallDie()
    {
        
    }

    public IEnumerable<BaseOrganism> CallReproduce()
    {

    }


}
