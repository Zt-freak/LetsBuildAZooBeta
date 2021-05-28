// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Research_.IconGrid.BG3D.Paw
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_Research_.IconGrid.BG3D
{
  internal class Paw : GameObject
  {
    public Paw()
    {
      this.DrawRect = new Rectangle(324, 128, 20, 16);
      this.SetAllColours(0.2705882f, 0.5058824f, 0.5019608f);
      this.scale = 2f;
      this.SetAlpha(0.5f);
    }

    public void PawDraw() => this.WorldOffsetDistanceDraw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet, this.vLocation, false);
  }
}
