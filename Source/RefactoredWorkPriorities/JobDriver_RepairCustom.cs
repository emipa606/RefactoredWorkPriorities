using System.Collections.Generic;
using RimWorld;
using Verse.AI;

namespace RWP
{
    // Token: 0x02000002 RID: 2
    public class JobDriver_RepairCustom : JobDriver_Repair
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
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
}