// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Employees.GeneralEmployees.EM_Bar.ColoumnBG
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_Employees.GeneralEmployees.EM_Bar
{
  internal class ColoumnBG
  {
    private GameObject BGFrame;
    private Vector2 VSCALE;

    public ColoumnBG(Vector2 CustFrameSize, float BaseScale, float PreMultipliedWidth)
    {
      this.BGFrame = new GameObject();
      this.BGFrame.DrawRect = TinyZoo.Game1.WhitePixelRect;
      this.BGFrame.SetDrawOriginToCentre();
      this.BGFrame.SetAllColours(0.0f, 0.0f, 0.0f);
      this.BGFrame.SetAlpha(0.1f);
      this.VSCALE = new Vector2(PreMultipliedWidth, CustFrameSize.Y);
    }

    public Vector2 GetSize() => this.VSCALE;

    public void UpdateColoumnBG()
    {
    }

    public void DrawColoumnBG(Vector2 Offset, SpriteBatch spritebatch) => this.BGFrame.Draw(spritebatch, AssetContainer.SpriteSheet, Offset, this.VSCALE);
  }
}
