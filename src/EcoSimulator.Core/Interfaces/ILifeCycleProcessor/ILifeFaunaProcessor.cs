namespace EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organism.Base;

public interface ILifeFaunaProcessor
{
    //First time of the Turn, the Processor calls the Grow() method of the FaunaOrganism Sub-Class
    public void CallGrow();

    // Second time of the Turn, the Processor calls the Eat() method of the FaunaOrganism Sub-Class
    public IEnumerable<Organism> CallEat();

    //Third time of the Turn, the Processor calls the Die() method of the FaunaOrganism Sub-Class if die
    public IEnumerable<Organism> CallDie();

    //Fourth time of the Turn, the Processor calls the Reproduce() method of the FaunaOrganism Sub-Class
    public IEnumerable<Organism> CallReproduce();
}