namespace EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Organism.Base;

public interface ILifeFloraProcessor
{
    public void CallGrow();

    public IEnumerable<Organism> CallDie();
}