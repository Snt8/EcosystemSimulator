using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Organism.Base;
namespace EcoSimulator.Core.Processors.BaseLifeCycleProcessor;

public class FaunaLifeCycleProcessor : ILifeFaunaProcessor
{
    public List<Organism> MasterOrganism {get; private set;}
    public List<Organism> MasterFoodOrganism {get; private set;}

    public void CallGrow()
    {

    }

    public IEnumerable<Organism> CallEat()
    {

    }

    public IEnumerable<Organism> CallDie()
    {

    }

    public IEnumerable<Organism> CallReproduce()
    {

    }


}
