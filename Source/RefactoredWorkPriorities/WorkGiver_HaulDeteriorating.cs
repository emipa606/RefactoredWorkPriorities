using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace RWP
{
    // Token: 0x02000009 RID: 9
    public class WorkGiver_HaulDeteriorating : WorkGiver_HaulGeneral
    {
        // Token: 0x17000003 RID: 3
        // (get) Token: 0x0600001A RID: 26 RVA: 0x000027F4 File Offset: 0x000009F4
        public override bool Prioritized => true;

        // Token: 0x0600001B RID: 27 RVA: 0x000027F7 File Offset: 0x000009F7
        public virtual bool ShouldSkip(Pawn pawn)
        {
            return !Settings.PrioritizeDeteriorating;
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00002801 File Offset: 0x00000A01
        public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            return 100f * t.HitPoints / t.MaxHitPoints >= Settings.DeterioratableMinHealthPercent &&
                   base.HasJobOnThing(pawn, t, forced);
        }

        // Token: 0x0600001D RID: 29 RVA: 0x0000282B File Offset: 0x00000A2B
        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            return from t in pawn.Map?.listerHaulables?.ThingsPotentiallyNeedingHauling()
                where t.Map != null && t.GetStatValue(StatDefOf.DeteriorationRate) > 0f &&
                      t.Position.GetRoof(t.Map) == null
                select t;
        }

        // Token: 0x0600001E RID: 30 RVA: 0x00002864 File Offset: 0x00000A64
        public override float GetPriority(Pawn pawn, TargetInfo t)
        {
            var thing = t.Thing;
            return thing.GetStatValue(StatDefOf.DeteriorationRate) / thing.HitPoints;
        }
    }
}