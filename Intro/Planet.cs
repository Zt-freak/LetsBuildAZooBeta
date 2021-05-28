// Decompiled with JetBrains decompiler
// Type: TinyZoo.Intro.Planet
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Intro
{
  internal class Planet : GameObject
  {
    public Planet()
    {
      this.DrawRect = new Rectangle(0, 225, 83, 83);
      this.SetDrawOriginToCentre();
      this.scale = RenderMath.GetPixelSizeBestMatch(3f);
      this.vLocation = new Vector2(150f, 300f);
      this.SetColours(false, 5f, 0.0f, 0.0f, 0.0f, 1f, 1f, 1f);
      this.SetColourDelay(1f);
    }

    public void UpdatePlanet(float DeltaTime)
    {
      this.vLocation.X += DeltaTime * 8f;
      this.UpdateColours(DeltaTime);
    }

    public void DrawPlanet(Vector2 ExtraOffset) => this.Draw(AssetContainer.pointspritebatch0, AssetContainer.SpriteSheet, ExtraOffset);
  }
}
