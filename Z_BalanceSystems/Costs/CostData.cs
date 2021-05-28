// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Costs.CostData
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.PlayerDir;

namespace TinyZoo.Z_BalanceSystems.Costs
{
  internal class CostData
  {
    internal static int GetNewLandCost(Player player)
    {
      int totalLandUnlocked = PlayerStats.GetTotalLandUnlocked();
      int num = 2500;
      if (Z_DebugFlags.IsBetaVersion)
        num = 300;
      return (totalLandUnlocked + 1) * num;
    }
  }
}
