// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_StoreRoom.AnimalFoodInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;

namespace TinyZoo.Z_StoreRoom
{
  internal class AnimalFoodInfo
  {
    public Rectangle DrawRect;
    public int DeliveryTime;
    public int Cost;
    public int ShelfLife;

    public AnimalFoodInfo(Rectangle _DrawRect, int _DeliveryTime, int _ShelfLife, int _Cost)
    {
      this.Cost = _Cost;
      this.DrawRect = _DrawRect;
      this.DeliveryTime = _DeliveryTime;
      this.ShelfLife = _ShelfLife;
    }
  }
}
