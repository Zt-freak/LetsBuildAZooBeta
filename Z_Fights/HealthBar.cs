// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Fights.HealthBar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.Z_SummaryPopUps.People.Customer.SatisfactionBars;

namespace TinyZoo.Z_Fights
{
  internal class HealthBar
  {
    private SatisfactionBar HPBar;

    public HealthBar()
    {
      this.HPBar = new SatisfactionBar(1f, barsize: BarSIze.VerySmall);
      this.HPBar.SetBarColours(new Vector3(1f, 0.0f, 0.0f));
    }

    public void SetHealthBarFullness(float _Fullness) => this.HPBar.SetFullness(_Fullness);

    public void DrawHealthBar(Vector2 AnimalLocation, float AlphaMult = 1f)
    {
      Vector2 screenSpace = RenderMath.TranslateWorldSpaceToScreenSpace(AnimalLocation);
      screenSpace.Y += 10f * Sengine.WorldOriginandScale.Z * Sengine.ScreenRatioUpwardsMultiplier.Y;
      this.HPBar.SetScale(Sengine.WorldOriginandScale.Z);
      this.HPBar.SetAllAlphas(AlphaMult);
      this.HPBar.DrawSatisfactionBar(screenSpace, AssetContainer.pointspritebatch03);
    }
  }
}
