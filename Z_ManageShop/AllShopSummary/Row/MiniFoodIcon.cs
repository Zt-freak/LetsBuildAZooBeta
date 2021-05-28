// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageShop.AllShopSummary.Row.MiniFoodIcon
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.Z_ManageShop.FoodIcon;

namespace TinyZoo.Z_ManageShop.AllShopSummary.Row
{
  internal class MiniFoodIcon : GameObject
  {
    private GameObject FoodThing;

    public MiniFoodIcon(FOODTYPE foodtype)
    {
      this.DrawRect = FoodIconData.GetFoodRectangle(foodtype);
      this.SetDrawOriginToCentre();
      this.scale = 1f;
    }

    public void DrawMiniFoodIcon(Vector2 Offset) => this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, Offset);
  }
}
