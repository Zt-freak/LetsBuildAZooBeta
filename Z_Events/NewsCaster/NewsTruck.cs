// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Events.NewsCaster.NewsTruck
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.Z_DayNight;

namespace TinyZoo.Z_Events.NewsCaster
{
  internal class NewsTruck : GameObject
  {
    public NewsTruck()
    {
      this.DrawRect = new Rectangle(0, 525, 69, 50);
      this.SetDrawOriginToPoint(DrawOriginPosition.CentreBottom);
      this.vLocation = TileMath.GetTileToWorldSpace(TileMath.GetGateLocationvector2Int() + new Vector2Int(7, 2));
    }

    public void UpdateNewsTruck()
    {
    }

    public void DrawNewsTruck()
    {
      this.SetAllColours(DayNightManager.SunShineValueR, DayNightManager.SunShineValueG, DayNightManager.SunShineValueB);
      this.WorldOffsetDraw(AssetContainer.pointspritebatch01, AssetContainer.AnimalSheet);
    }
  }
}
