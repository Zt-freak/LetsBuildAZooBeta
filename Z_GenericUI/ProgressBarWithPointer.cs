// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_GenericUI.ProgressBarWithPointer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;

namespace TinyZoo.Z_GenericUI
{
  internal class ProgressBarWithPointer
  {
    private GameObjectNineSlice bar;
    private Vector2 Vscale;
    private PointerAndText pointerandtext;
    public Vector2 Location;
    private float totalHeight;
    private ZGenericText headerTextObj;
    private UIScaleHelper scaleHelper;

    public ProgressBarWithPointer(
      string pointerText,
      float progress,
      float BaseScale,
      string headerText,
      float width = 158f,
      float height = 10f)
    {
      this.totalHeight = 0.0f;
      this.scaleHelper = new UIScaleHelper(BaseScale);
      progress = MathHelper.Clamp(progress, 0.0f, 1f);
      this.bar = new GameObjectNineSlice(new Rectangle(644, 592, 9, 9), 3);
      this.bar.scale = BaseScale;
      this.bar.SetDrawOriginToCentre();
      float y = this.scaleHelper.ScaleY(height);
      float x = this.scaleHelper.ScaleX(width);
      this.Vscale = new Vector2(x, y);
      this.totalHeight += y;
      if (!string.IsNullOrEmpty(headerText))
      {
        this.headerTextObj = new ZGenericText(headerText, BaseScale);
        Vector2 size = this.headerTextObj.GetSize();
        this.headerTextObj.vLocation.Y -= size.Y * 0.5f;
        this.headerTextObj.vLocation.Y -= y * 0.5f;
        this.totalHeight += size.Y;
      }
      if (string.IsNullOrEmpty(pointerText))
        return;
      float num = 5f * this.bar.scale;
      this.pointerandtext = new PointerAndText(pointerText, 1f, BaseScale, y / this.bar.scale + this.scaleHelper.ScaleX(4f));
      this.pointerandtext.vLocation.X += num;
      this.pointerandtext.vLocation.X += progress * (x - num * 2f);
      this.pointerandtext.vLocation.X -= x * 0.5f;
      this.totalHeight += this.pointerandtext.GetLineAndTextHeight();
    }

    public float GetWidth() => this.Vscale.X;

    public float GetHeight() => this.totalHeight;

    public float GetExtraOffsetFromTop()
    {
      float num = this.Vscale.Y * 0.5f;
      if (this.headerTextObj != null)
        num += this.headerTextObj.GetSize().Y;
      return num;
    }

    public void UpdateProgressBar()
    {
    }

    public void SetTint(Vector3 tintColor) => this.bar.SetAllColours(tintColor);

    public void SetPointerColor(Vector3 tintColor, bool TextToo = true) => this.pointerandtext.SetPointerColor(tintColor, TextToo);

    public void DrawProgressBar(Vector2 Offset, SpriteBatch spriteBatch)
    {
      Offset += this.Location;
      this.bar.DrawGameObjectNineSlice(spriteBatch, AssetContainer.SpriteSheet, Offset, this.Vscale);
      if (this.pointerandtext != null)
        this.pointerandtext.DrawPointerAndText(Offset);
      if (this.headerTextObj == null)
        return;
      this.headerTextObj.DrawZGenericText(Offset, spriteBatch);
    }

    public void DrawProgressBar(Vector2 Offset) => this.DrawProgressBar(Offset, AssetContainer.pointspritebatchTop05);
  }
}
