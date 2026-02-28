namespace EcoSimulator.Core.Interface;
using EcoSimulator.Core.Organisms.Base;

public interface IEat
{
    //Every FaunaOrganism need to Eat
    public void Eat(Organism food);
}