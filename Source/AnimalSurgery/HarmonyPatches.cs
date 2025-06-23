using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace AnimalArmourFix;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("mlie.VanillaFriendlyAnimalSurgery").PatchAll(Assembly.GetExecutingAssembly());
    }

    public static bool IsAnimalSurgery(string defName)
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
}