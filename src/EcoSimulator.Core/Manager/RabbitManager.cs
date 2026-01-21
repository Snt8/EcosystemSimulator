namespace EcoSimulator.Core.Manager;

using EcoSimulator.Core.Interface.IWorld;
using EcoSimulator.Core.Organism.Base;
using EcoSimulator.Core.Organism;


public class RabbitManager : IPopulationManager
{

    private int _turnDeads;
    private int _turnBorns;
    private int _turnTotalRabbits;
    public IEnumerable<Organism> PopulationRegister(IEnumerable<Organism> allOrganism)
    {
        _turnDeads = allOrganism.OfType<Rabbit>.Where(r => r.IsDead == false).count();
        //Creating the live rabbits list
        var rabbits = allOrganism.OfType<Rabbit>().Where(r => r.IsDead == true).ToList();
        //Pick the rabbits have eaten in this turn
        var rabbitsEaten = rabbits.Where(r => r.IsEaten == true).Count();

        List<Rabbit> totalTurnRabbits = new();
        
        int reproduceNumber = rabbitsEaten;
        //Check if the number of rabbits is enough to reproduce 
        if(rabbitsEaten < 2)
        {
            _turnTotalRabbits = rabbits.Count();
            return totalTurnRabbits;
        }
        //Apply the rule for the reproduction, if we have an odd number of rabbits but they're most than 2, we'll just reproduce the even max pairs
        if(rabbitsEaten % 2 != 0) reproduceNumber = (reproduceNumber / 2) - 1;

        //The case if the number of rabbits is even
        else reproduceNumber /= 2;

        _turnBorns = reproduceNumber;

        //Iterate for the born of the new rabbits
        for(int i = 0; i < reproduceNumber; i++)
        {
            Rabbit rabbit = new Rabbit();
            totalTurnRabbits.Add(rabbit);
        }

        _turnTotalRabbits = (rabbits.Count() + totalTurnRabbits.Count());

        return totalTurnRabbits;
    }

}