// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.StoreRooms.StockPredictor
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System;

namespace TinyZoo.PlayerDir.StoreRooms
{
  internal class StockPredictor
  {
    private float TotalStock;
    private float TotalUsedPerDay;
    private int ShelfLife;

    public StockPredictor(float _TotalStock, int _ShelfLife)
    {
      this.ShelfLife = _ShelfLife;
      this.TotalStock = _TotalStock;
    }

    public void AddPerDayOfThis(float _TotalUsedPerDay) => this.TotalUsedPerDay += _TotalUsedPerDay;

    public int GetDaysStockWIllLast()
    {
      if ((double) this.TotalUsedPerDay != 0.0)
        return Math.Min((int) Math.Floor((double) this.TotalStock / (double) this.TotalUsedPerDay), this.ShelfLife);
      return (double) this.TotalStock > 0.0 ? Math.Min(999, this.ShelfLife) : 0;
    }
  }
}
