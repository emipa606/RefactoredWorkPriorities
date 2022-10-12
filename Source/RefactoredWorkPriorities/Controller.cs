using Mlie;
using UnityEngine;
using Verse;

namespace RWP;

public class Controller : Mod
{
    private static string currentVersion;

    public Controller(ModContentPack content) : base(content)
    {
        GetSettings<Settings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.RefactoredWorkPriorities"));
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var text = "RWP_RepairThreshold_Label".Translate(Settings.RepairThreshold);
        var str = "RWP_RepairThreshold_Desc".Translate();
        var label = "RWP_PrioritizeRottable_Label".Translate();
        var tooltip = "RWP_PrioritizeRottable_Desc".Translate();
        var label2 = "RWP_PrioritizeDeteriorating_Label".Translate();
        var tooltip2 = "RWP_PrioritizeDeteriorating_Desc".Translate();
        var text2 = "RWP_DeterioratableMinHealthPercent_Label".Translate(Settings.DeterioratableMinHealthPercent);
        var str2 = "RWP_DeterioratableMinHealthPercent_Label_Desc".Translate();
        var listing_Standard = new Listing_Standard { ColumnWidth = inRect.width };
        listing_Standard.Begin(inRect);
        listing_Standard.Gap(20f);
        var rect = listing_Standard.GetRect(Text.LineHeight);
        var rect2 = rect.LeftHalf().Rounded();
        var rect3 = rect.RightHalf().Rounded();
        Widgets.Label(rect2, text);
        if (Mouse.IsOver(rect2))
        {
            Widgets.DrawHighlight(rect2);
        }

        TooltipHandler.TipRegion(rect2, str);
        if (Widgets.ButtonText(new Rect(rect3.xMin, rect3.y, rect3.height, rect3.height), "-", true, false) &&
            Settings.RepairThreshold is <= 100 and > 0)
        {
            Settings.RepairThreshold--;
        }

        Settings.RepairThreshold = Mathf.RoundToInt(Widgets.HorizontalSlider(
            new Rect(rect3.xMin + rect3.height + 10f, rect3.y, rect3.width - ((rect3.height * 2f) + 20f),
                rect3.height), Settings.RepairThreshold, 0f, 100f, true));
        if (Widgets.ButtonText(new Rect(rect3.xMax - rect3.height, rect3.y, rect3.height, rect3.height), "+", true,
                false) && Settings.RepairThreshold is < 100 and >= 0)
        {
            Settings.RepairThreshold++;
        }

        listing_Standard.Gap(20f);
        listing_Standard.CheckboxLabeled(label, ref Settings.PrioritizeRottable, tooltip);
        listing_Standard.Gap(20f);
        listing_Standard.CheckboxLabeled(label2, ref Settings.PrioritizeDeteriorating, tooltip2);
        listing_Standard.Gap(20f);
        var rect4 = listing_Standard.GetRect(Text.LineHeight);
        var rect5 = rect4.LeftHalf().Rounded();
        var rect6 = rect4.RightHalf().Rounded();
        Widgets.Label(rect5, text2);
        if (Mouse.IsOver(rect5))
        {
            Widgets.DrawHighlight(rect5);
        }

        TooltipHandler.TipRegion(rect5, str2);
        if (Widgets.ButtonText(new Rect(rect6.xMin, rect6.y, rect6.height, rect6.height), "-", true, false) &&
            Settings.DeterioratableMinHealthPercent is <= 100 and > 0)
        {
            Settings.DeterioratableMinHealthPercent--;
        }

        Settings.DeterioratableMinHealthPercent = Mathf.RoundToInt(Widgets.HorizontalSlider(
            new Rect(rect6.xMin + rect6.height + 10f, rect6.y, rect6.width - ((rect6.height * 2f) + 20f),
                rect6.height), Settings.DeterioratableMinHealthPercent, 0f, 100f, true));
        if (Widgets.ButtonText(new Rect(rect6.xMax - rect6.height, rect6.y, rect6.height, rect6.height), "+", true,
                false) && Settings.DeterioratableMinHealthPercent is < 100 and >= 0)
        {
            Settings.DeterioratableMinHealthPercent++;
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("RWP_CurrentModVersion_Label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override string SettingsCategory()
    {
        return "Refactored Work Priorities";
    }
}