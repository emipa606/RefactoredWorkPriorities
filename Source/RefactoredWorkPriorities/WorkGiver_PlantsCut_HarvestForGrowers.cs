using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RWP;

public class WorkGiver_PlantsCut_HarvestForGrowers : WorkGiver_PlantsCut
{
    public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
    {
        var allDesignations = pawn.Map.designationManager.AllDesignations;
        int num;
        for (var i = 0; i < allDesignations.Count; i = num + 1)
        {
            var designation = allDesignations[i];
            if (designation.def == DesignationDefOf.HarvestPlant)
            {
                if (designation.target.Thing is Plant plant && plant.def.plant.harvestedThingDef != null)
                {
                    yield return designation.target.Thing;
                }
            }

            num = i;
        }
    }
}