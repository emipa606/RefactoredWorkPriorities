using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace RWP;

public class WorkGiver_HaulRottable : WorkGiver_HaulGeneral
{
    public override bool Prioritized => true;

    public virtual bool ShouldSkip(Pawn pawn)
    {
        return !Settings.PrioritizeRottable;
    }

    public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
    {
        return from t in pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling().ToArray()
            where t.Map != null && t.def.comps.Exists(tc => tc.compClass == typeof(CompRottable))
            select t;
    }

    public override float GetPriority(Pawn pawn, TargetInfo t)
    {
        var thing = t.Thing;
        var daysToRotStart = thing.def.GetCompProperties<CompProperties_Rottable>().daysToRotStart;
        if (thing.TryGetComp<CompRottable>().RotProgressPct * 100f >= 90f)
        {
            return 0f;
        }

        return 1f / daysToRotStart;
    }
}