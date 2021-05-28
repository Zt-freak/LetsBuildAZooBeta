// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.ControlHint.MiniMouseIcon
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_HUD.ControlHint
{
  internal class MiniMouseIcon : GameObject
  {
    public MiniMouseIcon(MouseHintButton mousebutton, float BaseScale)
    {
      switch (mousebutton)
      {
        case MouseHintButton.LeftMouse:
          this.DrawRect = new Rectangle(519, 112, 17, 23);
          break;
        case MouseHintButton.RightMouse:
          this.DrawRect = new Rectangle(537, 112, 17, 23);
          break;
        case MouseHintButton.MiddleMouse:
          this.DrawRect = new Rectangle(555, 112, 17, 23);
          break;
      }
      this.SetDrawOriginToCentre();
      this.scale = BaseScale;
    }

    public Vector2 GetSize() => new Vector2((float) this.DrawRect.Width, (float) this.DrawRect.Height) * this.scale * Sengine.ScreenRatioUpwardsMultiplier;

    public void UpdateMiniMouseIcon()
    {
    }

    public void DrawMiniMouseIcon(Vector2 Offset, SpriteBatch spriteBatch) => this.Draw(spriteBatch, AssetContainer.SpriteSheet, Offset);
  }
}
