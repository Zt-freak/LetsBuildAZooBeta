// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.ParkSummary.Finances.Revenue.Table.FinanceTableRowTypeContainer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Tile_Data;

namespace TinyZoo.Z_SummaryPopUps.ParkSummary.Finances.Revenue.Table
{
  internal class FinanceTableRowTypeContainer
  {
    public FinanceTableRowType rowType;
    public TILETYPE tileType;

    public FinanceTableRowTypeContainer(FinanceTableRowType _rowType, TILETYPE _tileType = TILETYPE.Count)
    {
      this.rowType = _rowType;
      this.tileType = _tileType;
    }
  }
}
