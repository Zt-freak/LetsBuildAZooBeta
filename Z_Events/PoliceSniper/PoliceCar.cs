// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Events.PoliceSniper.PoliceCar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.Z_DayNight;

namespace TinyZoo.Z_Events.PoliceSniper
{
  internal class PoliceCar : GameObject
  {
    public PoliceCar()
    {
      this.DrawRect = new Rectangle(0, 576, 56, 42);
      this.SetDrawOriginToPoint(DrawOriginPosition.CentreBottom);
    }

    public void UpdatePoliceCar(float DeltaTime)
    {
    }

    public void DrawPoliceCar()
    {
      this.vLocation = TileMath.GetTileToWorldSpace(TileMath.GetGateLocationvector2Int() + new Vector2Int(12, 2));
      this.SetAllColours(DayNightManager.SunShineValueR, DayNightManager.SunShineValueG, DayNightManager.SunShineValueB);
      this.WorldOffsetDraw(AssetContainer.pointspritebatch01, AssetContainer.AnimalSheet);
    }
  }
}
