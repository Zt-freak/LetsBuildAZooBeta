// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_GenericUI.FlatWhiteNineSliceFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_GenericUI
{
  internal class FlatWhiteNineSliceFrame : GameObjectNineSlice
  {
    public Vector2 VSCale;

    public FlatWhiteNineSliceFrame()
      : base(new Rectangle(873, 282, 21, 21), 7)
    {
      this.scale = 2f;
    }

    public FlatWhiteNineSliceFrame(Vector2 _vScale)
      : base(new Rectangle(873, 282, 21, 21), 7)
    {
      this.VSCale = _vScale;
    }

    public void DrawFlatWhiteNineSliceFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.vLocation;
      this.DrawGameObjectNineSlice(spriteBatch, AssetContainer.SpriteSheet, offset, this.VSCale);
    }
  }
}
