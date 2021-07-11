using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RWP
{
    // Token: 0x02000007 RID: 7
    public class WorkGiver_PlantsCut_IgnoreHarvestable : WorkGiver_PlantsCut
    {
        // Token: 0x06000016 RID: 22 RVA: 0x00002776 File Offset: 0x00000976
        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            var allDesignations = pawn.Map.designationManager.allDesignations;
            int num;
            for (var i = 0; i < allDesignations.Count; i = num + 1)
            {
                var designation = allDesignations[i];
                if (designation.def == DesignationDefOf.CutPlant)
                {
                    yield return designation.target.Thing;
                }
                else if (designation.def == DesignationDefOf.HarvestPlant)
                {
                    if (designation.target.Thing is Plant plant &&
                        (plant.def.plant.IsTree || plant.def.plant.harvestedThingDef == null))
                    {
                        yield return designation.target.Thing;
                    }
                }

                num = i;
            }
        }
    }
}