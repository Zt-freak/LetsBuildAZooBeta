// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageShop.Shop_Data.ShopStatsCollection
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;

namespace TinyZoo.Z_ManageShop.Shop_Data
{
  internal class ShopStatsCollection
  {
    public List<ShopStatEntry> shopstats;
    public RecipeEntry Seasoning;
    public float MaxServingTime = 5f;
    public float MinServingTime = 1f;
    public int CustomerCapacity;

    public ShopStatsCollection(RecipeEntry _Seasoning)
    {
      this.shopstats = new List<ShopStatEntry>();
      this.Seasoning = _Seasoning;
    }

    public void SetUpServing(int _CustomerCapacity) => this.CustomerCapacity = _CustomerCapacity;
  }
}
