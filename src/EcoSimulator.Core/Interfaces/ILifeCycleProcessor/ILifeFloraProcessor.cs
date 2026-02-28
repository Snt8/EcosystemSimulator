namespace EcoSimulator.Core.Interface.ILifeCycleProcessor;

using System.Xml.Serialization;
using EcoSimulator.Core.Organisms.Base;

public interface ILifeFloraProcessor
{
    //First turn the processor calls Grow method in a FloraOrganism subclass
    void CallGrow();

    //Second turn the processor calls Die method if a FloraOrganism subclass dies
    IEnumerable<Organism> CallDie();
}