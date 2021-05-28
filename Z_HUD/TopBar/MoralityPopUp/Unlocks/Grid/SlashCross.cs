// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.TopBar.MoralityPopUp.Unlocks.Grid.SlashCross
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_HUD.TopBar.MoralityPopUp.Unlocks.Grid
{
  internal class SlashCross : GameObject
  {
    public SlashCross(float BaseScale)
    {
      this.DrawRect = new Rectangle(763, 920, 32, 32);
      this.scale = BaseScale;
      this.SetDrawOriginToCentre();
    }

    public void UpdateSlashCross()
    {
    }

    public void DrawSlashCross(Vector2 offset, SpriteBatch spriteBatch, float scaleMult = 1f) => this.Draw(spriteBatch, AssetContainer.SpriteSheet, offset, this.scale * scaleMult, this.fAlpha);
  }
}
