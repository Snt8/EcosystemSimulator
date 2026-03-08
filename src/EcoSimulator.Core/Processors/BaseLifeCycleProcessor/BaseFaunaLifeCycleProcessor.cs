using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using BaseOrganism = EcoSimulator.Core.Organisms.Base.Organism;
using EcoSimulator.Core.Organisms.Base;

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
        List<FaunaOrganism> eatenFood = new();
        foreach(var organism in MasterFoodOrganism.OfType<IEat>)
        {

        }

    }

    public IEnumerable<BaseOrganism> CallDie()
    {

    }

    public IEnumerable<BaseOrganism> CallReproduce()
    {

    }


}
