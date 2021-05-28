// Decompiled with JetBrains decompiler
// Type: TinyZoo.TitleScreen.TScreenFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.TitleScreen
{
  internal class TScreenFrame
  {
    public GameObjectNineSlice tframe;
    public Vector2 VScale;

    public TScreenFrame(float BaseScale, bool IsMouseOver = false, bool IsDark = false)
    {
      this.tframe = !IsDark ? (!IsMouseOver ? new GameObjectNineSlice(new Rectangle(992, 434, 21, 21), 7) : new GameObjectNineSlice(new Rectangle(948, 484, 21, 21), 7)) : new GameObjectNineSlice(new Rectangle(907, 582, 21, 21), 7);
      this.tframe.scale = BaseScale;
      this.tframe.SetAlpha(0.6f);
    }

    public bool CheckForCollision(Vector2 Offset, Vector2 TouchPoint) => MathStuff.CheckPointCollision(true, Offset + this.tframe.vLocation, 1f, this.VScale.X, this.VScale.Y, TouchPoint);

    public void UpdateTScreenFrame()
    {
    }

    public void DrawTScreenFrame(Vector2 Offset) => this.tframe.DrawGameObjectNineSlice(AssetContainer.pointspritebatch03, AssetContainer.SpriteSheet, Offset, this.VScale);
  }
}
