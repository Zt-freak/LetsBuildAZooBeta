// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Commodities.Warehouse
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.Z_StoreRoom;

namespace TinyZoo.PlayerDir.Commodities
{
  internal class Warehouse
  {
    private WarehouseStock[] warehousestock;

    public Warehouse()
    {
      this.warehousestock = new WarehouseStock[88];
      for (int index = 0; index < this.warehousestock.Length; ++index)
        this.warehousestock[index] = new WarehouseStock();
    }

    public void AddStockToWareHouse(AnimalFoodType ThingToAdd, int Things) => this.warehousestock[(int) ThingToAdd].AddStock(Things);

    public WarehouseStock[] GetWarehouseStock() => this.warehousestock;

    public void SaveWarehouse(Writer writer)
    {
      writer.WriteInt("J", this.warehousestock.Length);
      for (int index = 0; index < this.warehousestock.Length; ++index)
        this.warehousestock[index].SaveWarehouseStock(writer);
    }

    public Warehouse(Reader reader)
    {
      this.warehousestock = new WarehouseStock[88];
      int _out = 0;
      for (int index = 0; index < this.warehousestock.Length; ++index)
        this.warehousestock[index] = new WarehouseStock();
      int num = (int) reader.ReadInt("J", ref _out);
      for (int index = 0; index < _out; ++index)
        this.warehousestock[index] = new WarehouseStock(reader);
    }
  }
}
