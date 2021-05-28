﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageShop.Shop_Data.ShopStatEntry
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_ManageShop.FoodIcon;

namespace TinyZoo.Z_ManageShop.Shop_Data
{
  internal class ShopStatEntry
  {
    public FOODTYPE MainItemForSale;
    public int MinStockCost;
    public int MaxSellToPublicCost;
    public int IdealCost;
    public int IdealMin;
    public int IdealMax;
    public string VariantA;
    public string VariantB;
    public int VariantAWeight;
    public RecipeList recipe;

    public ShopStatEntry(
      FOODTYPE _Name,
      int _MinStockCost,
      int _IdealCost,
      string _VariantA,
      string _VariantB,
      int _VariantAWeight,
      int _IdealMin = -1,
      int _IdealMax = -1)
    {
      this.IdealMin = _IdealMin;
      this.IdealMax = _IdealMax;
      this.MainItemForSale = _Name;
      this.MinStockCost = _MinStockCost;
      this.IdealCost = _IdealCost;
      this.VariantA = _VariantA;
      this.VariantB = _VariantB;
    }
  }
}
