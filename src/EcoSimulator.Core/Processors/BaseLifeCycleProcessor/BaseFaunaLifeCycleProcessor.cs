using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using BaseOrganism = EcoSimulator.Core.Organisms.Base.Organism;
using EcoSimulator.Core.Organisms.Base;

namespace EcoSimulator.Core.Processors.BaseLifeCycleProcessor;

public class FaunaLifeCycleProcessor : ILifeFaunaProcessor
{
    public List<FaunaOrganism> MasterOrganism {get; private set;}
    public List<BaseOrganism> MasterFoodOrganism {get; private set;}


    public void CallGrow()
    {
        foreach (var organism in MasterOrganism)
        {
            organism.Grow();
        }

    }

    public IEnumerable<BaseOrganism> CallEat()
    {

    }

    public IEnumerable<BaseOrganism> CallDie()
    {

    }

    public IEnumerable<BaseOrganism> CallReproduce()
    {

    }


}
