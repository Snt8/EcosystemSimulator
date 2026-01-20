namespace EcoSimulator.Core.Interface.IWorld;

public interface IPopulationManager
{
    public IEnumerable<Organism> PopulationRegister(IEnumerable<Organism> allOrganisms);
    //Interface that tell the world the changes stats of the simulation round

    public SpeciesReport GetTurnReport();
}