namespace EcoSimulator.Core.Manager;

using System.Collections.Generic;
using System.Linq;
using EcoSimulator.Core.Interface.IWorld;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism;
using EcoSimulator.Core.Organism.SpeciesReport;
using EcoSimulator.Core.Organism.OrganismDataConfig;


public class RabbitManager : IPopulationManager
{

    private int _turnDeads;
    private int _turnBorns;
    private int _turnTotalRabbits;
    private readonly FaunaConfig _config;

    public RabbitManager(FaunaConfig config)
    {
        _config = config;
    }

    public IEnumerable<Organism> PopulationRegister(IEnumerable<Organism> allOrganism)
    {
        //Count the deads happens in the turn
        _turnDeads = allOrganism.OfType<Rabbit>().Where(r => r.IsDead).Count();
        
        //Select the alive rabbits
        var rabbits = allOrganism.OfType<Rabbit>().Where(r => !r.IsDead).ToList();
        
        //Select the rabbits has eaten
        var rabbitsEaten = rabbits.Where(r => r.HasEaten).Count();

        List<Rabbit> totalTurnRabbits = new();
        
        int reproduceNumber = rabbitsEaten;
        //Check if the number of rabbits is enough to reproduce 
        if(rabbitsEaten < 2)
        {
            _turnTotalRabbits = rabbits.Count();
            return totalTurnRabbits;
        }
        //Integer division automatically handles the odd numbers (floors the result)
        reproduceNumber /= 2;

        _turnBorns = reproduceNumber;

        //Iterate for the born of the new rabbits
        for(int i = 0; i < reproduceNumber; i++)
        {
            Rabbit rabbit = new Rabbit(_config);
            totalTurnRabbits.Add(rabbit);
        }

        _turnTotalRabbits = (rabbits.Count() + totalTurnRabbits.Count());

        return totalTurnRabbits;
    }

    public SpeciesReport GetTurnReport()
    {
        //Build the SpeciesReport instance to be used in the Simulation Report 
        return new SpeciesReport(nameof(Rabbit), _turnBorns, _turnTotalRabbits, _turnDeads);
    }
}