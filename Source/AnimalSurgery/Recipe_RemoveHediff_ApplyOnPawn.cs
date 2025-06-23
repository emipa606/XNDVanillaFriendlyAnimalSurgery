using HarmonyLib;
using RimWorld;
using Verse;

namespace AnimalArmourFix;

[HarmonyPatch(typeof(Recipe_RemoveHediff), nameof(Recipe_RemoveHediff.ApplyOnPawn))]
public static class Recipe_RemoveHediff_ApplyOnPawn
{
    private static void Prefix(Recipe_RemoveHediff __instance, ref Pawn pawn, ref BodyPartRecord part,
        out Hediff __state)
    {
        var currentPart = part;
        var hediff = pawn.health.hediffSet.hediffs.Find(x =>
            x.def == __instance.recipe.removesHediff && x.Part == currentPart && x.Visible);
        __state = hediff;
    }

    private static void Postfix(ref Pawn billDoer, Hediff __state)
    {
        if (HarmonyPatches.IsAnimalSurgery(__state.def.defName) && __state.def.spawnThingOnRemoved != null)
        {
            GenSpawn.Spawn(__state.def.spawnThingOnRemoved, billDoer.Position, billDoer.Map);
        }
    }
}