// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageShop.AllShopSummary.Row.C02_Type
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System;
using TinyZoo.Tile_Data;
using TinyZoo.Z_ManagePen.Diet.SingleAnimalSummary.MainAnimalFood;
using TinyZoo.Z_ManageShop.Shop_Data;

namespace TinyZoo.Z_ManageShop.AllShopSummary.Row
{
  internal class C02_Type
  {
    private TopTextMini toptextmini;
    private TopTextMini toptextminiTwo;
    public Vector2 Location;

    public C02_Type(float HeightForText, TILETYPE tiletype, float MidTextHeight, float BaseScale)
    {
      Console.WriteLine("BaseScaleNotApplied");
      this.toptextmini = new TopTextMini("Type", BaseScale, HeightForText, false, true);
      this.toptextmini.CenterJustify = true;
      this.toptextminiTwo = new TopTextMini(ShopData.WhatDoesThisShopSell(tiletype), BaseScale, MidTextHeight);
      this.toptextminiTwo.CenterJustify = true;
    }

    public void DrawColumn(Vector2 Offset)
    {
      Offset += this.Location;
      this.toptextmini.DrawTopTextMini(Offset);
      this.toptextminiTwo.DrawTopTextMini(Offset);
    }
  }
}
