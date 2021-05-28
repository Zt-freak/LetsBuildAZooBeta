﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.ProductionLines.TotalsAndBuildings
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;

namespace TinyZoo.Z_BalanceSystems.ProductionLines
{
  internal class TotalsAndBuildings
  {
    public List<Vector3Int> UID_AndCount;

    public TotalsAndBuildings() => this.UID_AndCount = new List<Vector3Int>();

    public void AddStockWithUID(int ShopUID, int AddThisMany)
    {
      for (int index = 0; index < this.UID_AndCount.Count; ++index)
      {
        if (this.UID_AndCount[index].X == ShopUID)
        {
          this.UID_AndCount[index].Y += AddThisMany;
          return;
        }
      }
      this.UID_AndCount.Add(new Vector3Int(ShopUID, AddThisMany, 0));
    }
  }
}
