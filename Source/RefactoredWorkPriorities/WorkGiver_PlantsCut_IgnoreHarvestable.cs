using System;
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
			List<Designation> allDesignations = pawn.Map.designationManager.allDesignations;
			int num;
			for (int i = 0; i < allDesignations.Count; i = num + 1)
			{
				Designation designation = allDesignations[i];
				if (designation.def == DesignationDefOf.CutPlant)
				{
					yield return designation.target.Thing;
				}
				else if (designation.def == DesignationDefOf.HarvestPlant)
				{
					Plant plant = designation.target.Thing as Plant;
					if (plant != null && (plant.def.plant.IsTree || plant.def.plant.harvestedThingDef == null))
					{
						yield return designation.target.Thing;
					}
				}
				designation = null;
				num = i;
			}
			yield break;
		}
	}
}
