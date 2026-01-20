namespace EcoSimulator.Core.Interface.IWorld;


public interface IWorld
{
    public void StartTurn();
    //Method for start the Organism generation, and the ecosisten Simulation
    
    public void ManagerCall();
    //Method to use the Manager for get the new Organism and the total dies

    public void CleanWorld();
    //Method to check the Organism and clean the dies
}