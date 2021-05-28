// Decompiled with JetBrains decompiler
// Type: TinyZoo.GenericUI.UXPanels.Coin
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.GenericUI.UXPanels
{
  internal class Coin : GameObject
  {
    public Coin()
    {
      this.scale = RenderMath.GetPixelSizeBestMatch(2f);
      this.DrawRect = new Rectangle(138, 0, 7, 7);
      this.SetDrawOriginToCentre();
    }

    public void DrawCoin(SpriteBatch DrawWithThis, Vector2 Offset) => this.Draw(DrawWithThis, AssetContainer.SpriteSheet, Offset);
  }
}
