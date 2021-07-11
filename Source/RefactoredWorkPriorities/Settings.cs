using Verse;

namespace RWP
{
    // Token: 0x02000004 RID: 4
    public class Settings : ModSettings
    {
        // Token: 0x04000001 RID: 1
        public static int RepairThreshold = 100;

        // Token: 0x04000002 RID: 2
        public static bool PrioritizeRottable = true;

        // Token: 0x04000003 RID: 3
        public static bool PrioritizeDeteriorating = true;

        // Token: 0x04000004 RID: 4
        public static int DeterioratableMinHealthPercent = 35;

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600000D RID: 13 RVA: 0x00002314 File Offset: 0x00000514
        public static DesignationDef DefOf_RWP_ForcedRepair => DefDatabase<DesignationDef>.GetNamed("RWP_ForcedRepair");

        // Token: 0x0600000E RID: 14 RVA: 0x00002324 File Offset: 0x00000524
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref RepairThreshold, "RepairThreshold", 100);
            Scribe_Values.Look(ref PrioritizeRottable, "PrioritizeRottable", true);
            Scribe_Values.Look(ref PrioritizeDeteriorating, "PrioritizeDeteriorating", true);
            Scribe_Values.Look(ref DeterioratableMinHealthPercent, "DeterioratableMinHealthPercent", 35);
        }
    }
}