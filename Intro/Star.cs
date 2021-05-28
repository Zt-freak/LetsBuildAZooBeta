// Decompiled with JetBrains decompiler
// Type: TinyZoo.Intro.Star
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using System;

namespace TinyZoo.Intro
{
  internal class Star : GameObject
  {
    public Star(Random rnd)
    {
      this.DrawRect = new Rectangle(168, 225, 9, 9);
      this.SetDrawOriginToCentre();
      this.DrawRect.X += 10 * rnd.Next(0, 6);
      this.vLocation = MathStuff.GetRandomVector2(Vector2.Zero, new Vector2(1024f, 768f), rnd);
    }

    public void UpdateStar()
    {
    }

    public void DrawStar(Vector2 ExtraOffset) => this.Draw(AssetContainer.pointspritebatch0, AssetContainer.SpriteSheet, ExtraOffset);
  }
}
