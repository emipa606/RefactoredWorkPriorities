using System.Collections.Generic;
using RimWorld;
using Verse.AI;

namespace RWP;

public class JobDriver_RepairCustom : JobDriver_Repair
{
    protected override IEnumerable<Toil> MakeNewToils()
    {
        void NewAct()
        {
            var actor = GetActor();
            var curJob = actor.jobs.curJob;
            if (curJob.targetA.Thing.HitPoints == curJob.targetA.Thing.MaxHitPoints)
            {
                actor.Map.designationManager.RemoveAllDesignationsOn(curJob.targetA.Thing);
            }
        }

        AddFinishAction(NewAct);
        foreach (var toil in base.MakeNewToils())
        {
            yield return toil;
        }
    }
}