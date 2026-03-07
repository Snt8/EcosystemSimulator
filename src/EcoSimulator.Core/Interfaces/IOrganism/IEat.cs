using EcoSimulator.Core.Organisms.Base;

namespace EcoSimulator.Core.Interface;

public interface IEat
{
    //Every FaunaOrganism need to Eat
    public void Eat(Organism food);
}