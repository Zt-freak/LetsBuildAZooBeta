// Decompiled with JetBrains decompiler
// Type: TinyZoo.GenericUI.CustomerFrameMousOverBox
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.GenericUI
{
  internal class CustomerFrameMousOverBox
  {
    public bool Active;
    private CustomerFrame customerFrame;
    private CustomerFrame outlineFrame;
    private SimpleTextHandler zooLocationText;
    private Vector2 location;
    private float BaseScale;
    private float paraWidth;

    public CustomerFrameMousOverBox(float _BaseScale, string textToWrite, float UnMultipliedWidth)
    {
      this.BaseScale = _BaseScale;
      UIScaleHelper uiScaleHelper = new UIScaleHelper(this.BaseScale);
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      this.paraWidth = UnMultipliedWidth * this.BaseScale - defaultXbuffer;
      float num1 = defaultYbuffer;
      float num2 = defaultXbuffer;
      this.zooLocationText = new SimpleTextHandler(textToWrite, this.paraWidth, _Scale: this.BaseScale, AutoComplete: true);
      this.zooLocationText.SetAllColours(ColourData.Z_Cream);
      float y = num1 + (this.zooLocationText.GetHeightOfParagraph() + defaultYbuffer);
      float x = num2 + (this.paraWidth + defaultXbuffer);
      Vector2 vector2 = uiScaleHelper.ScaleVector2(Vector2.One * 4f);
      this.customerFrame = new CustomerFrame(new Vector2(x, y) - vector2, ColourData.Z_FrameLightBrown, this.BaseScale);
      this.outlineFrame = new CustomerFrame(this.customerFrame.VSCale + vector2, ColourData.Z_Cream, this.BaseScale);
      this.zooLocationText.Location = new Vector2(this.customerFrame.VSCale.X * -0.5f, y);
      this.zooLocationText.Location.X += defaultXbuffer;
      this.zooLocationText.Location.Y = this.customerFrame.VSCale.Y * -0.5f;
      this.zooLocationText.Location.Y += defaultYbuffer;
    }

    public void SetText(string NewText)
    {
      Vector2 location = this.zooLocationText.Location;
      this.zooLocationText = new SimpleTextHandler(NewText, this.paraWidth, _Scale: this.BaseScale, AutoComplete: true);
      this.zooLocationText.SetAllColours(ColourData.Z_Cream);
      this.zooLocationText.Location = location;
    }

    public CustomerFrameMousOverBox(Vector2 size, float _BaseScale)
    {
      this.BaseScale = _BaseScale;
      Vector2 vector2 = new UIScaleHelper(this.BaseScale).ScaleVector2(Vector2.One * 4f);
      this.customerFrame = new CustomerFrame(size - vector2, ColourData.Z_FrameLightBrown, this.BaseScale);
      this.outlineFrame = new CustomerFrame(this.customerFrame.VSCale + vector2, ColourData.Z_Cream, this.BaseScale);
    }

    public Vector2 GetSize() => this.outlineFrame.VSCale;

    public void DrawCustomerFrameMouseOverBoc(Vector2 offset, SpriteBatch spriteBatch)
    {
      if (!this.Active)
        return;
      if (this.zooLocationText != null)
      {
        offset.Y -= this.outlineFrame.VSCale.Y * 0.5f;
        offset.Y -= 10f * this.BaseScale * Sengine.ScreenRatioUpwardsMultiplier.Y;
      }
      this.Active = false;
      offset += this.location;
      this.outlineFrame.DrawCustomerFrame(offset, spriteBatch);
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      if (this.zooLocationText == null)
        return;
      this.zooLocationText.DrawSimpleTextHandler(offset, 1f, spriteBatch);
    }
  }
}
