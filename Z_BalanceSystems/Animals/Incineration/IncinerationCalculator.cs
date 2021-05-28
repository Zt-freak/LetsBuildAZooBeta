// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Animals.Incineration.IncinerationCalculator
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.PlayerDir.Incinerator;
using TinyZoo.Z_Animal_Data;

namespace TinyZoo.Z_BalanceSystems.Animals.Incineration
{
  internal class IncinerationCalculator
  {
    public static float GetMinutesToProcess(
      DeadAnimal deadanimal,
      float EfficiencyMultiplier,
      bool IsIncinerator)
    {
      if ((double) deadanimal.weight == 0.0)
        deadanimal.weight = (float) AnimalData.GetAnimalWeight(deadanimal.animalType);
      return deadanimal.weight * 60f * EfficiencyMultiplier;
    }
  }
}
