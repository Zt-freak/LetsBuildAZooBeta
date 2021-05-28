// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Animal.Shared.FoodBars.NutritionBar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_SummaryPopUps.People.Animal.Shared.FoodBars
{
  internal class NutritionBar : GameObject
  {
    private GameObject TopBar;

    public NutritionBar(bool IsNutrion, float BaseScale)
    {
      this.DrawRect = new Rectangle(937, 438, 53, 10);
      this.scale = BaseScale;
      this.TopBar = new GameObject((GameObject) this);
      if (IsNutrion)
        this.TopBar.DrawRect = new Rectangle(937, 449, 53, 10);
      else
        this.TopBar.DrawRect = new Rectangle(937, 460, 53, 10);
    }

    public void SetFullness(float Fullness) => this.TopBar.DrawRect.Width = (int) (2.0 + 49.0 * (double) Fullness);

    public void DrawNutritionBar(Vector2 Offset)
    {
      this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, Offset);
      this.TopBar.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, Offset + this.vLocation);
    }
  }
}
