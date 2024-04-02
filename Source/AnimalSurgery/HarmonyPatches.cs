using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace AnimalArmourFix;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        var harmonyInstance = new Harmony("mlie.VanillaFriendlyAnimalSurgery");
        harmonyInstance.Patch(AccessTools.Method(typeof(Recipe_RemoveHediff), nameof(Recipe_RemoveHediff.ApplyOnPawn)),
            new HarmonyMethod(typeof(HarmonyPatches), nameof(RemoveHediff_Prefix)),
            new HarmonyMethod(typeof(HarmonyPatches), nameof(RemoveHediff_Postfix)));
        harmonyInstance.Patch(
            AccessTools.Method(typeof(Recipe_InstallImplant), nameof(Recipe_InstallImplant.ApplyOnPawn)),
            new HarmonyMethod(typeof(HarmonyPatches), nameof(SpawnHediff_Prefix)));
    }

    private static bool IsAnimalSurgery(string defName)
    {
        var listOfSurgeries = new List<string>
        {
            "InstallAnimalNaturalHeart",
            "InstallAnimalNaturalKidney",
            "InstallAnimalNaturalLiver",
            "InstallAnimalNaturalLung",
            "InstallAnimalDenture",
            "InstallPegAnimalLeg",
            "InstallSimpleProstheticAnimalArm",
            "InstallSimpleProstheticAnimalLeg",
            "InstallBionicAnimalArm",
            "InstallBionicAnimalEye",
            "InstallAnimalPainstopper"
        };
        foreach (var surgery in listOfSurgeries)
        {
            if (defName.StartsWith(surgery))
            {
                return true;
            }
        }

        return false;
    }

    private static void RemoveHediff_Prefix(Recipe_RemoveHediff __instance, ref Pawn pawn, ref BodyPartRecord part,
        out Hediff __state)
    {
        var currentPart = part;
        var hediff = pawn.health.hediffSet.hediffs.Find(x =>
            x.def == __instance.recipe.removesHediff && x.Part == currentPart && x.Visible);
        __state = hediff;
    }

    private static void RemoveHediff_Postfix(ref Pawn billDoer, Hediff __state)
    {
        Log.Message(__state.def.defName);
        if (IsAnimalSurgery(__state.def.defName) && __state.def.spawnThingOnRemoved != null)
        {
            GenSpawn.Spawn(__state.def.spawnThingOnRemoved, billDoer.Position, billDoer.Map);
        }
    }

    private static void SpawnHediff_Prefix(Recipe_InstallImplant __instance, ref Pawn pawn, ref BodyPartRecord part,
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
            if (hediff.Part != part || !IsAnimalSurgery(hediff.def.defName) ||
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