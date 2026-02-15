namespace EcoSimulator.Core.Interface.ILifeCycleProcessor;
using EcoSimulator.Core.Organism.Base;

public interface ILifeFloraProcessor
{
    void CallGrow();
    IEnumerable<Organism> CallDie();
}