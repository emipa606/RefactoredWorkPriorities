using System.Collections.Generic;
using RimWorld;
using Verse.AI;

namespace RWP;

public class JobDriver_RepairCustom : JobDriver_Repair
{
    protected override IEnumerable<Toil> MakeNewToils()
    {
        AddFinishAction(delegate
        {
            var actor = GetActor();
            var curJob = actor.jobs.curJob;
            if (curJob.targetA.Thing.HitPoints == curJob.targetA.Thing.MaxHitPoints)
            {
                actor.Map.designationManager.RemoveAllDesignationsOn(curJob.targetA.Thing);
            }
        });
        foreach (var toil in base.MakeNewToils())
        {
            yield return toil;
        }
    }
}