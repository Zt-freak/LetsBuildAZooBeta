// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.ProductionLines.ProductionLineCalc
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_BalanceSystems.ProductionLines
{
  internal class ProductionLineCalc
  {
    internal static TotalsAndBuildings[] totalsAndBuildings = new TotalsAndBuildings[88];

    internal static void ReinitialzeOnGameStart() => ProductionLineCalc.totalsAndBuildings = new TotalsAndBuildings[88];

    internal static void StartNewDay(Player player)
    {
      ProductionLineCalc.totalsAndBuildings = new TotalsAndBuildings[88];
      for (int index = 0; index < player.shopstatus.FacilitiesWithEmployees.Count; ++index)
        player.shopstatus.FacilitiesWithEmployees[index].StartNewDay();
    }
  }
}
