// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Animals.CRISPR.CRISPRCalculator
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_BalanceSystems.Animals.CRISPR
{
  internal class CRISPRCalculator
  {
    public static float GetDaysForThisCRISPRBreed(AnimalType animalOne, AnimalType animalTwo)
    {
      if (Z_DebugFlags.QuickCRISPRBreeds)
        return 1f;
      float num = (float) (ActiveBreed.GetDaysForpregnancy(animalOne) + ActiveBreed.GetDaysForpregnancy(animalTwo)) * 1.5f;
      return Z_DebugFlags.IsBetaVersion ? 4f : num;
    }
  }
}
