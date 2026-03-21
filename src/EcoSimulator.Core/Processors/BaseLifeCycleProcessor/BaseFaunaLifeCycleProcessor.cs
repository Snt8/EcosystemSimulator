using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using BaseOrganism = EcoSimulator.Core.Organisms.Base.Organism;
using EcoSimulator.Core.Organisms.Base;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.IOrganism;

namespace EcoSimulator.Core.Processors.BaseLifeCycleProcessor;

public class FaunaLifeCycleProcessor : ILifeFaunaProcessor
{
    public List<FaunaOrganism> MasterOrganism {get; private set;}
    public List<BaseOrganism> MasterFoodOrganism {get; private set;}
    public Queue<BaseOrganism> UneatedFood { get; private set; }
    private readonly Func<BaseOrganism>? _spawnOrganismFactory;

    public FaunaLifeCycleProcessor(List<FaunaOrganism> MasterOrgnaism, List<BaseOrganism> MasterFoodOrganism, Func<BaseOrganism>? spawnOrganismFactory = null)
    {
        this.MasterOrganism = MasterOrgnaism;
        this.MasterFoodOrganism = MasterFoodOrganism;
        this._spawnOrganismFactory = spawnOrganismFactory;

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
        List<BaseOrganism> diedOrganisms = new();
        foreach (var organism in MasterOrganism.OfType<IDie>())
        {
            organism.Die();

            //Checking if our organism die
            if (organism is BaseOrganism baseOrg && baseOrg.IsDead)
            {
                diedOrganisms.Add(baseOrg);
            }
        }

        return diedOrganisms;
    }

    public IEnumerable<BaseOrganism> CallReproduce()
    {
        //Check the organisms are avaible for reproduce
        var aviableReproductionOrganisms = MasterOrganism.Where(r => r.HasEaten && r.Energy > r.ReproduceEnergy).ToList();

        int reproductionCount = aviableReproductionOrganisms.Count / 2;
        List<BaseOrganism> newOrganisms = new(reproductionCount);

        //Iterate for check the number of new organisms
        for(int reproductionTimes = 0; reproductionTimes < reproductionCount; reproductionTimes++)
        {
            // Update parents state (reset HasEaten) so they need to eat again before reproducing
            aviableReproductionOrganisms[reproductionTimes * 2].Reproduce();
            aviableReproductionOrganisms[(reproductionTimes * 2) + 1].Reproduce();

            if (_spawnOrganismFactory != null)
            {
                newOrganisms.Add(_spawnOrganismFactory());
            }
        }

        return newOrganisms;
    }


}
