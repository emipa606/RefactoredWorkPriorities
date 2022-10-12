using RimWorld;
using Verse;

namespace RWP;

public class WorkGiver_RepairCustom : WorkGiver_Repair
{
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