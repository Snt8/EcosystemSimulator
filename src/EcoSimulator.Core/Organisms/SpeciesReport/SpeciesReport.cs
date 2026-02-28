namespace EcoSimulator.Core.Organisms.SpeciesReport;

public class SpeciesReport 
{
    public string SpecieName {get; private set;}
    public int Borns {get; private set;}
    public int AliveOrganism {get; private set;}
    public int Deads {get; private set;}

    public SpeciesReport(string objSpecieName, int objBorns, int objAliveOrganism, int objDeads)
    {
        //Creating the report Data
        SpecieName = objSpecieName;
        Borns = objBorns;
        AliveOrganism = objAliveOrganism;
        Deads = objDeads;
    }
}