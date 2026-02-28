using System;
using EcoSimulator.Core.Interface;
using EcoSimulator.Core.Interface.IOrganism;
using EcoSimulator.Core.Organisms.Base;
using EcoSimulator.Core.Organisms.OrganismDataConfig;

namespace EcoSimulator.Core.Organisms;



public sealed class Rabbit : FaunaOrganism
{
    public Rabbit(FaunaConfig config) : base(config, config.MaxEnergy, config.FaunaReproduceEnergy)
    {
    }

    public override void Eat(Organism food)
    {
        // Call base to check common rules (like IsDead)
        base.Eat(food);
        if (IsDead) return;
        
        if (food is FloraOrganism flora && !flora.IsEaten && !flora.IsDead)
        {
            // Policy: Check type. Mechanics: Delegate to base.
            IngestFood(flora.EnergyGiven, flora.HungryMinus);
            flora.IsEaten = true;
        }
    }
}