using RimWorld;
using Verse;

namespace RWP
{
    // Token: 0x02000008 RID: 8
    public class WorkGiver_RepairCustom : WorkGiver_Repair
    {
        // Token: 0x06000018 RID: 24 RVA: 0x00002788 File Offset: 0x00000988
        public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            if (forced)
            {
                return base.HasJobOnThing(pawn, t, true);
            }

            if (pawn.Map.designationManager.DesignationOn(t, Settings.DefOf_RWP_ForcedRepair) != null)
            {
                return base.HasJobOnThing(pawn, t);
            }

            return 100f * t.HitPoints / t.MaxHitPoints <= Settings.RepairThreshold && base.HasJobOnThing(pawn, t);
        }
    }
}