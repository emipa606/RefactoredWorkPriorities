using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace RWP
{
	// Token: 0x0200000A RID: 10
	public class WorkGiver_HaulRottable : WorkGiver_HaulGeneral
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000027F4 File Offset: 0x000009F4
		public override bool Prioritized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002895 File Offset: 0x00000A95
		public virtual bool ShouldSkip(Pawn pawn)
		{
			return !Settings.PrioritizeRottable;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000289F File Offset: 0x00000A9F
		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
		{
			return from t in pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling()
			where t.def.comps.Exists((CompProperties tc) => tc.compClass == typeof(CompRottable))
			select t;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000028D8 File Offset: 0x00000AD8
		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Thing thing = t.Thing;
			float daysToRotStart = thing.def.GetCompProperties<CompProperties_Rottable>().daysToRotStart;
			if (thing.TryGetComp<CompRottable>().RotProgressPct * 100f >= 90f)
			{
				return 0f;
			}
			return 1f / daysToRotStart;
		}
	}
}
