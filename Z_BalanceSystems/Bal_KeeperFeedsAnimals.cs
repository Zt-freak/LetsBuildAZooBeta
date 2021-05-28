// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Bal_KeeperFeedsAnimals
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.Layout.CellBlocks;
using TinyZoo.Z_AnimalsAndPeople.Sim_Person.Extras;

namespace TinyZoo.Z_BalanceSystems
{
  internal class Bal_KeeperFeedsAnimals
  {
    internal static int KeeperFeedAnimals(
      HungryAnimal hungryanaimalset,
      Player player,
      Employee Ref_Employee,
      ref UsedFoodCollection foodused,
      AnimalFoodDistribution fooddistribution)
    {
      return hungryanaimalset.TryToFeed(player, Ref_Employee.CarryCapacity, ref foodused, fooddistribution);
    }
  }
}
