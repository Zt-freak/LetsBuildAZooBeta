// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_GenericUI.ZCheckBox
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_GenericUI
{
  internal class ZCheckBox
  {
    private Rectangle emptyBoxRect;
    private Rectangle tickedBoxRect;
    public GameObject checkBox;
    private bool isTicked;
    public Vector2 location;
    private bool mouseOver;
    private Vector2 extraTouchCollision;

    public ZCheckBox(float BaseScale)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      this.emptyBoxRect = new Rectangle(670, 416, 18, 18);
      this.tickedBoxRect = new Rectangle(689, 416, 18, 18);
      this.checkBox = new GameObject();
      this.checkBox.DrawRect = this.emptyBoxRect;
      this.checkBox.SetDrawOriginToCentre();
      this.checkBox.scale = BaseScale;
      this.extraTouchCollision = uiScaleHelper.ScaleVector2(new Vector2(15f, 15f));
    }

    public bool UpdateCheckBox(Player player, Vector2 offset)
    {
      offset += this.location;
      this.mouseOver = MathStuff.CheckPointCollision(true, offset, 1f, this.extraTouchCollision.X + (float) this.checkBox.DrawRect.Width * this.checkBox.scale, this.extraTouchCollision.Y + (float) this.checkBox.DrawRect.Height * this.checkBox.scale * Sengine.ScreenRatioUpwardsMultiplier.Y, player.inputmap.PointerLocation);
      return MathStuff.CheckPointCollision(true, offset, 1f, this.extraTouchCollision.X + (float) this.checkBox.DrawRect.Width * this.checkBox.scale, this.extraTouchCollision.Y + (float) this.checkBox.DrawRect.Height * this.checkBox.scale * Sengine.ScreenRatioUpwardsMultiplier.Y, player.player.touchinput.ReleaseTapArray[0]);
    }

    public void SetColorTint(Vector3 color) => this.checkBox.SetAllColours(color);

    public bool GetIsTicked() => this.isTicked;

    public void SetTicked(bool _isTicked)
    {
      this.isTicked = _isTicked;
      if (this.isTicked)
        this.checkBox.DrawRect = this.tickedBoxRect;
      else
        this.checkBox.DrawRect = this.emptyBoxRect;
    }

    public Vector2 GetSize() => new Vector2((float) this.checkBox.DrawRect.Width * this.checkBox.scale, (float) this.checkBox.DrawRect.Height * this.checkBox.scale) * Sengine.ScreenRatioUpwardsMultiplier;

    public void DrawCheckBox(SpriteBatch spriteBatch, Vector2 offset)
    {
      offset += this.location;
      this.checkBox.Draw(spriteBatch, AssetContainer.SpriteSheet, offset);
    }
  }
}
