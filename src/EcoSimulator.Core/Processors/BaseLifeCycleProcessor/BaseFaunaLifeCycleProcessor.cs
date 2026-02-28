using EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Organisms.Base;
namespace EcoSimulator.Core.Processors.BaseLifeCycleProcessor;

public class FaunaLifeCycleProcessor : ILifeFaunaProcessor
{
    public List<> MasterOrganism {get; private set;}
    public List<Organism> MasterFoodOrganism {get; private set;}


    public void CallGrow()
    {
        foreach (Organism organism in MasterOrganism)
        {
            organism.Grow();
        }
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
