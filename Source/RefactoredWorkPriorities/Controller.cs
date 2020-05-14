using System;
using UnityEngine;
using Verse;

namespace RWP
{
	// Token: 0x02000005 RID: 5
	public class Controller : Mod
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000023A1 File Offset: 0x000005A1
		public Controller(ModContentPack content) : base(content)
		{
			base.GetSettings<Settings>();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023B4 File Offset: 0x000005B4
		public override void DoSettingsWindowContents(Rect inRect)
		{
			string text = "RWP_RepairThreshold_Label".Translate(new object[]
			{
				Settings.RepairThreshold
			});
			string str = Translator.Translate("RWP_RepairThreshold_Desc");
			string label = Translator.Translate("RWP_PrioritizeRottable_Label");
			string tooltip = Translator.Translate("RWP_PrioritizeRottable_Desc");
			string label2 = Translator.Translate("RWP_PrioritizeDeteriorating_Label");
			string tooltip2 = Translator.Translate("RWP_PrioritizeDeteriorating_Desc");
			string text2 = "RWP_DeterioratableMinHealthPercent_Label".Translate(new object[]
			{
				Settings.DeterioratableMinHealthPercent
			});
			string str2 = Translator.Translate("RWP_DeterioratableMinHealthPercent_Label_Desc");
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.ColumnWidth = inRect.width;
			listing_Standard.Begin(inRect);
			listing_Standard.Gap(20f);
			Rect rect = listing_Standard.GetRect(Text.LineHeight);
			Rect rect2 = GenUI.Rounded(GenUI.LeftHalf(rect));
			Rect rect3 = GenUI.Rounded(GenUI.RightHalf(rect));
			Widgets.Label(rect2, text);
			if (Mouse.IsOver(rect2))
			{
				Widgets.DrawHighlight(rect2);
			}
			TooltipHandler.TipRegion(rect2, str);
			if (Widgets.ButtonText(new Rect(rect3.xMin, rect3.y, rect3.height, rect3.height), "-", true, false, true) && Settings.RepairThreshold <= 100 && Settings.RepairThreshold > 0)
			{
				Settings.RepairThreshold--;
			}
			Settings.RepairThreshold = Mathf.RoundToInt(Widgets.HorizontalSlider(new Rect(rect3.xMin + rect3.height + 10f, rect3.y, rect3.width - (rect3.height * 2f + 20f), rect3.height), (float)Settings.RepairThreshold, 0f, 100f, true, null, null, null, -1f));
			if (Widgets.ButtonText(new Rect(rect3.xMax - rect3.height, rect3.y, rect3.height, rect3.height), "+", true, false, true) && Settings.RepairThreshold < 100 && Settings.RepairThreshold >= 0)
			{
				Settings.RepairThreshold++;
			}
			listing_Standard.Gap(20f);
			listing_Standard.CheckboxLabeled(label, ref Settings.PrioritizeRottable, tooltip);
			listing_Standard.Gap(20f);
			listing_Standard.CheckboxLabeled(label2, ref Settings.PrioritizeDeteriorating, tooltip2);
			listing_Standard.Gap(20f);
			Rect rect4 = listing_Standard.GetRect(Text.LineHeight);
			Rect rect5 = GenUI.Rounded(GenUI.LeftHalf(rect4));
			Rect rect6 = GenUI.Rounded(GenUI.RightHalf(rect4));
			Widgets.Label(rect5, text2);
			if (Mouse.IsOver(rect5))
			{
				Widgets.DrawHighlight(rect5);
			}
			TooltipHandler.TipRegion(rect5, str2);
			if (Widgets.ButtonText(new Rect(rect6.xMin, rect6.y, rect6.height, rect6.height), "-", true, false, true) && Settings.DeterioratableMinHealthPercent <= 100 && Settings.DeterioratableMinHealthPercent > 0)
			{
				Settings.DeterioratableMinHealthPercent--;
			}
			Settings.DeterioratableMinHealthPercent = Mathf.RoundToInt(Widgets.HorizontalSlider(new Rect(rect6.xMin + rect6.height + 10f, rect6.y, rect6.width - (rect6.height * 2f + 20f), rect6.height), (float)Settings.DeterioratableMinHealthPercent, 0f, 100f, true, null, null, null, -1f));
			if (Widgets.ButtonText(new Rect(rect6.xMax - rect6.height, rect6.y, rect6.height, rect6.height), "+", true, false, true) && Settings.DeterioratableMinHealthPercent < 100 && Settings.DeterioratableMinHealthPercent >= 0)
			{
				Settings.DeterioratableMinHealthPercent++;
			}
			listing_Standard.End();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002757 File Offset: 0x00000957
		public override string SettingsCategory()
		{
			return "Refactored Work Priorities";
		}
	}
}
