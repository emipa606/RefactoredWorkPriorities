using System;
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
			List<Designation> allDesignations = pawn.Map.designationManager.allDesignations;
			int num;
			for (int i = 0; i < allDesignations.Count; i = num + 1)
			{
				Designation designation = allDesignations[i];
				if (designation.def == DesignationDefOf.HarvestPlant)
				{
					Plant plant = designation.target.Thing as Plant;
					if (plant != null && plant.def.plant.harvestedThingDef != null)
					{
						yield return designation.target.Thing;
					}
				}
				num = i;
			}
			yield break;
		}
	}
}
