namespace EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;

public interface ILifeFaunaProcessor
{
    //First time of the Turn, the Processor calls the Grow() method of the FaunaOrganism Sub-Class
    public void CallGrow(IEnumerable<IGrow> organisms);

    // Second time of the Turn, the Processor calls the Eat() method of the FaunaOrganism Sub-Class
    public IEnumerable<Organism> CallEat(IEnumerable<IEat> faunaOrganisms, IEnumerable<FloraOrganism> food);

    //Third time of the Turn, the Processor calls the Die() method of the FaunaOrganism Sub-Class if die
    public IEnumerable<FaunaOrganism> CallDie(IEnumerable<IDie> organisms);
}