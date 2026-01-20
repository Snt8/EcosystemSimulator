namespace EcoSimulator.Core.Interface;
using EcoSimulator.Core.Organism.Base;

public interface IEat
{
    //Every FaunaOrganism need to Eat
    public void Eat(FloraOrganism food);
}