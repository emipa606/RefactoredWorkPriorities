using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace RWP;

public class WorkGiver_HaulDeteriorating : WorkGiver_HaulGeneral
{
    public override bool Prioritized => true;

    public virtual bool ShouldSkip(Pawn pawn)
    {
        return !Settings.PrioritizeDeteriorating;
    }

    public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
    {
        return 100f * t.HitPoints / t.MaxHitPoints >= Settings.DeterioratableMinHealthPercent &&
               base.HasJobOnThing(pawn, t, forced);
    }

    public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
    {
        return from t in pawn.Map?.listerHaulables?.ThingsPotentiallyNeedingHauling()
            where t.Map != null && t.GetStatValue(StatDefOf.DeteriorationRate) > 0f &&
                  t.Position.GetRoof(t.Map) == null
            select t;
    }

    public override float GetPriority(Pawn pawn, TargetInfo t)
    {
        var thing = t.Thing;
        return thing.GetStatValue(StatDefOf.DeteriorationRate) / thing.HitPoints;
    }
}