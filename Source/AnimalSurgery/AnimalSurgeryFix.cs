﻿using System.Linq;
using Verse;

namespace AnimalArmourFix
{
    [StaticConstructorOnStartup]
    public static class AnimalArmourFix
    {
        static AnimalArmourFix()
        {
            var animalsInGame = (from animal in DefDatabase<ThingDef>.AllDefsListForReading
                                 where animal.race != null &&
                                       animal.race.Animal
                                 select animal).ToList();
            foreach (ThingDef animalDef in animalsInGame)
            {
                switch (animalDef.race.baseBodySize)
                {
                    case float n when n >= 2.4f:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalHeartHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalKidneyHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLiverHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLungHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalDentureHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallPegAnimalLegHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalArmHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalLegHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalArmHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalEyeHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalPainstopperHuge", false));
                        break;
                    case float n when n >= 1.3f:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalHeartLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalKidneyLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLiverLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLungLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalDentureLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallPegAnimalLegLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalArmLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalLegLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalArmLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalEyeLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalPainstopperLarge", false));
                        break;
                    case float n when n >= 0.7f:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalHeartMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalKidneyMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLiverMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLungMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalDentureMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallPegAnimalLegMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalArmMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalLegMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalArmMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalEyeMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalPainstopperMedium", false));
                        break;
                    case float n when n >= 0.3f:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalHeartSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalKidneySmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLiverSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLungSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalDentureSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallPegAnimalLegSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalArmSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalLegSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalArmSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalEyeSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalPainstopperSmall", false));
                        break;
                    default:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalHeartTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalKidneyTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLiverTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalNaturalLungTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalDentureTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallPegAnimalLegTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalArmTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallSimpleProstheticAnimalLegTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalArmTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallBionicAnimalEyeTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallAnimalPainstopperTiny", false));
                        break;
                }
            }
            if(Prefs.DevMode)
            {
                Log.Message($"XND Vanilla-Friendly Animal Surgery: Added surgery recipies to {animalsInGame.Count} animal-spieces");
            }
        }
    }
}