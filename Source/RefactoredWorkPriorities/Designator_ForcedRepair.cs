using System;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace RWP
{
	// Token: 0x02000003 RID: 3
	public class Designator_ForcedRepair : Designator
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020D0 File Offset: 0x000002D0
		public Designator_ForcedRepair()
		{
			this.defaultLabel = Translator.Translate("Designator_ForcedRepair");
			this.defaultDesc = Translator.Translate("Designator_ForcedRepairDesc");
			this.icon = ContentFinder<Texture2D>.Get("Designations/ForcedRepair", true);
			this.soundDragSustain = SoundDefOf.Designate_DragStandard;
			this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
			this.useMouseIcon = true;
			this.soundSucceeded = SoundDefOf.Designate_Deconstruct;
			this.hotKey = KeyBindingDef.Named("DesignatorForcedRepair");
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x0000214C File Offset: 0x0000034C
		public override int DraggableDimensions
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002150 File Offset: 0x00000350
		public override AcceptanceReport CanDesignateCell(IntVec3 c)
		{
			if (!c.InBounds(base.Map))
			{
				return false;
			}
			if (c.Fogged(base.Map))
			{
				return false;
			}
			if (!base.Map.thingGrid.ThingsAt(c).Any((Thing t) => this.CanDesignateThing(t).Accepted))
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021B8 File Offset: 0x000003B8
		public override void DesignateSingleCell(IntVec3 loc)
		{
			foreach (Thing t in base.Map.thingGrid.ThingsAt(loc))
			{
				if (this.CanDesignateThing(t).Accepted)
				{
					this.DesignateThing(t);
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002224 File Offset: 0x00000424
		public override void DesignateThing(Thing t)
		{
			base.Map.designationManager.AddDesignation(new Designation(t, Settings.DefOf_RWP_ForcedRepair));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002248 File Offset: 0x00000448
		public override AcceptanceReport CanDesignateThing(Thing t)
		{
			if (!base.Map.listerBuildingsRepairable.RepairableBuildings(Faction.OfPlayer).Contains(t))
			{
				return false;
			}
			if (t.HitPoints >= t.MaxHitPoints)
			{
				return false;
			}
			if (base.Map.designationManager.DesignationOn(t, DesignationDefOf.Deconstruct) != null)
			{
				return false;
			}
			if (base.Map.designationManager.DesignationOn(t, DesignationDefOf.Uninstall) != null)
			{
				return false;
			}
			if (base.Map.designationManager.DesignationOn(t, Settings.DefOf_RWP_ForcedRepair) != null)
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000022F1 File Offset: 0x000004F1
		public override void SelectedUpdate()
		{
			GenUI.RenderMouseoverBracket();
		}
	}
}
