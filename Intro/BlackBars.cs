// Decompiled with JetBrains decompiler
// Type: TinyZoo.Intro.BlackBars
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Intro
{
  internal class BlackBars : GameObject
  {
    private Vector2 VScale;

    public BlackBars()
    {
      this.DrawRect = TinyZoo.Game1.WhitePixelRect;
      this.SetDrawOriginToPoint(DrawOriginPosition.TopLeft);
      this.VScale = new Vector2(1024f, 100f);
      this.SetAllColours(0.0f, 0.0f, 1f);
    }

    public void DrawBlackBars()
    {
      this.SetAllColours(ColourData.FernLemon);
      float y = 3f;
      this.Draw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet, new Vector2(0.0f, y), this.VScale);
      this.Draw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet, new Vector2(0.0f, 768f - y), this.VScale * new Vector2(1f, -1f));
      this.SetAllColours(0.0f, 0.0f, 0.0f);
      this.Draw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet, Vector2.Zero, this.VScale);
      this.Draw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet, new Vector2(0.0f, 768f), this.VScale * new Vector2(1f, -1f));
    }
  }
}
