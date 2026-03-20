namespace EcoSimulator.Core.Interface.IWorld;
using EcoSimulator.Core.Organisms.Base;
using EcoSimulator.Core.Organisms.SpeciesReport;

public interface IPopulationManager
{
    public IEnumerable<Organism> PopulationRegister(IEnumerable<Organism> allOrganisms);
    //Interface that tell the world the changes stats of the simulation round

    public SpeciesReport GetTurnReport();
}