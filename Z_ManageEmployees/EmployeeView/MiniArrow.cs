// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.EmployeeView.MiniArrow
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_ManageEmployees.EmployeeView
{
  internal class MiniArrow : GameObject
  {
    public Vector2 location;

    public MiniArrow(float BaseScale)
    {
      this.DrawRect = new Rectangle(69, 205, 11, 6);
      this.scale = BaseScale;
      this.SetDrawOriginToCentre();
    }

    public void SetPointingDown()
    {
      this.SetAllColours(ColourData.Z_ArrowAndTextRed);
      this.Rotation = 3.141593f;
    }

    public void SetNeutral() => this.SetAllColours(ColourData.Z_Cream);

    public void SetPointingUp() => this.SetAllColours(ColourData.Z_ArrowAndTextGreen);

    public Vector2 GetSize() => new Vector2((float) this.DrawRect.Width, (float) this.DrawRect.Height) * this.scale * Sengine.ScreenRatioUpwardsMultiplier;

    public void DrawMiniArrow(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.Draw(spriteBatch, AssetContainer.SpriteSheet, offset);
    }
  }
}
