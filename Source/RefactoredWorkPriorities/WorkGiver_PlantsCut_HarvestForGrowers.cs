using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RWP
{
    // Token: 0x02000006 RID: 6
    public class WorkGiver_PlantsCut_HarvestForGrowers : WorkGiver_PlantsCut
    {
        // Token: 0x06000014 RID: 20 RVA: 0x0000275E File Offset: 0x0000095E
        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            var allDesignations = pawn.Map.designationManager.allDesignations;
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
}