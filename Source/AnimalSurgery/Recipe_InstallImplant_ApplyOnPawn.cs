using HarmonyLib;
using RimWorld;
using Verse;

namespace AnimalArmourFix;

[HarmonyPatch(typeof(Recipe_InstallImplant), nameof(Recipe_RemoveHediff.ApplyOnPawn))]
public static class Recipe_InstallImplant_ApplyOnPawn
{
    private static void Prefix(Recipe_InstallImplant __instance, ref Pawn pawn, ref BodyPartRecord part,
        ref Pawn billDoer)
    {
        if (pawn.RaceProps.Humanlike || __instance.recipe.addsHediff == null ||
            !__instance.recipe.addsHediff.defName.Contains("AnimalArmor"))
        {
            return;
        }

        var hediffs = pawn.health.hediffSet.hediffs;
        for (var i = hediffs.Count - 1; i >= 0; i--)
        {
            var hediff = hediffs[i];
            if (hediff.Part != part || !HarmonyPatches.IsAnimalSurgery(hediff.def.defName) ||
                hediff.def.defName == __instance.recipe.addsHediff.defName)
            {
                continue;
            }

            var hediff2 = hediffs[i];
            pawn.health.RemoveHediff(hediff2);
            GenSpawn.Spawn(hediff2.def.spawnThingOnRemoved, billDoer.Position, billDoer.Map);
        }
    }
}