// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.StoreRooms.OrderEntry
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.Z_StoreRoom;

namespace TinyZoo.PlayerDir.StoreRooms
{
  internal class OrderEntry
  {
    public AnimalFoodType Item;
    public int DaysUntilDelivery;
    public int TotalOrdered;

    public OrderEntry(AnimalFoodType _Item, int _DaysUntilDelivery, int _TotalOrdered)
    {
      this.Item = _Item;
      this.DaysUntilDelivery = _DaysUntilDelivery;
      this.TotalOrdered = _TotalOrdered;
    }

    public void SaveOrderEntry(Writer writer)
    {
      writer.WriteInt("s", (int) this.Item);
      writer.WriteInt("s", this.DaysUntilDelivery);
      writer.WriteInt("s", this.TotalOrdered);
    }

    public OrderEntry(Reader reader)
    {
      int _out = 0;
      int num1 = (int) reader.ReadInt("s", ref _out);
      this.Item = (AnimalFoodType) _out;
      int num2 = (int) reader.ReadInt("s", ref this.DaysUntilDelivery);
      int num3 = (int) reader.ReadInt("s", ref this.TotalOrdered);
    }
  }
}
