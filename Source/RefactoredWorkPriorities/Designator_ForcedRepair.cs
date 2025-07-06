using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace RWP;

public class Designator_ForcedRepair : Designator
{
    public Designator_ForcedRepair()
    {
        defaultLabel = "Designator_ForcedRepair".Translate();
        defaultDesc = "Designator_ForcedRepairDesc".Translate();
        icon = ContentFinder<Texture2D>.Get("Designations/ForcedRepair");
        soundDragSustain = SoundDefOf.Designate_DragStandard;
        soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
        useMouseIcon = true;
        soundSucceeded = SoundDefOf.Designate_Deconstruct;
        hotKey = KeyBindingDef.Named("DesignatorForcedRepair");
    }

    public override DrawStyleCategoryDef DrawStyleCategory => DrawStyleCategoryDefOf.Orders;

    public override AcceptanceReport CanDesignateCell(IntVec3 c)
    {
        if (!c.InBounds(Map))
        {
            return false;
        }

        return !c.Fogged(Map) && Map.thingGrid.ThingsAt(c).Any(t => CanDesignateThing(t).Accepted);
    }

    public override void DesignateSingleCell(IntVec3 loc)
    {
        foreach (var t in Map.thingGrid.ThingsAt(loc))
        {
            if (CanDesignateThing(t).Accepted)
            {
                DesignateThing(t);
            }
        }
    }

    public override void DesignateThing(Thing t)
    {
        Map.designationManager.AddDesignation(new Designation(t, Settings.DefOf_RWP_ForcedRepair));
    }

    public override AcceptanceReport CanDesignateThing(Thing t)
    {
        if (!Map.listerBuildingsRepairable.RepairableBuildings(Faction.OfPlayer).Contains(t))
        {
            return false;
        }

        if (t.HitPoints >= t.MaxHitPoints)
        {
            return false;
        }

        if (Map.designationManager.DesignationOn(t, DesignationDefOf.Deconstruct) != null)
        {
            return false;
        }

        if (Map.designationManager.DesignationOn(t, DesignationDefOf.Uninstall) != null)
        {
            return false;
        }

        return Map.designationManager.DesignationOn(t, Settings.DefOf_RWP_ForcedRepair) == null;
    }

    public override void SelectedUpdate()
    {
        GenUI.RenderMouseoverBracket();
    }
}