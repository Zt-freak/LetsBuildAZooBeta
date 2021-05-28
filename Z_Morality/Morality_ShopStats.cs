﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Morality.Morality_ShopStats
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System;

namespace TinyZoo.Z_Morality
{
  internal class Morality_ShopStats
  {
    internal static void CalculateMorality_ShopStats(Player player, ref float Morality)
    {
      if (player.shopstatus.shopentries.Count <= 0)
        return;
      float num1 = 0.0f;
      for (int index = 0; index < player.shopstatus.shopentries.Count; ++index)
        num1 += player.shopstatus.shopentries[index].shopstockstatus[0].StockSliderValues[0];
      float num2 = (num1 / (float) player.shopstatus.shopentries.Count - 0.5f) * 2f;
      float num3 = Math.Min(MoralityData.MaxIngredientScale, (float) Math.Max(1, player.shopstatus.shopentries.Count / 2));
      Morality += num2 * num3;
    }
  }
}
