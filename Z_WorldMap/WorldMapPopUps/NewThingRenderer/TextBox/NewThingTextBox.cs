// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer.TextBox.NewThingTextBox
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.GenericUI;
using TinyZoo.Z_Collection.Shared.Grid;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer.TextBox
{
  internal class NewThingTextBox
  {
    public Vector2 location;
    private CustomerFrame frame;
    private ScreenHeading screenHeading;
    private SimpleTextHandler para;
    private SimpleTextHandler smallPara;
    private TextButton textButton;

    public NewThingTextBox(List<AnimalRenderDescriptor> animals, float BaseScale)
    {
      float defaultYbuffer = new UIScaleHelper(BaseScale).GetDefaultYBuffer();
      float num1 = 0.0f;
      float x = 300f * BaseScale;
      this.screenHeading = new ScreenHeading(SEngine.Localization.Localization.GetText(947), 28f, BaseScale: BaseScale, UseSmallerOnePointFiveFont: true);
      this.screenHeading.header.vLocation = Vector2.Zero;
      float num2 = num1 + ((float) ((double) this.screenHeading.header.VScale.Y * (double) Sengine.ScreenRatioUpwardsMultiplier.Y * 0.5) + defaultYbuffer);
      string text1 = SEngine.Localization.Localization.GetText(936);
      string TextToWrite = string.Format(SEngine.Localization.Localization.GetText(950), (object) EnemyData.GetEnemyTypeName(animals[0].bodyAnimalType), (object) animals.Count);
      float width_ = x * 0.9f;
      string text2 = SEngine.Localization.Localization.GetText(948);
      this.para = new SimpleTextHandler(TextToWrite, width_, true, BaseScale, true, true);
      this.para.SetAllColours(ColourData.Z_FrameMidBrown);
      this.para.Location.Y = num2;
      this.para.Location.Y += this.para.GetHeightOfOneLine() * 0.5f;
      float num3 = num2 + this.para.GetHeightOfParagraph();
      this.smallPara = new SimpleTextHandler(text2, width_, true, BaseScale, AutoComplete: true);
      this.smallPara.SetAllColours(ColourData.Z_FrameMidBrown);
      this.smallPara.Location.Y = num3;
      this.smallPara.Location.Y += this.smallPara.GetHeightOfOneLine() * 0.5f;
      float num4 = num3 + (this.smallPara.GetHeightOfParagraph() + defaultYbuffer * 0.5f);
      this.textButton = new TextButton(BaseScale, text1, 50f);
      this.textButton.vLocation.Y = num4 + this.textButton.GetSize_True().Y * 0.5f;
      float y = num4 + (this.textButton.GetSize_True().Y + defaultYbuffer);
      this.frame = new CustomerFrame(new Vector2(x, y), CustomerFrameColors.CreamWithBorder, BaseScale);
      Vector2 vector2 = -this.frame.VSCale * 0.5f;
      this.screenHeading.header.vLocation.Y += vector2.Y;
      this.para.Location.Y += vector2.Y;
      this.smallPara.Location.Y += vector2.Y;
      this.textButton.vLocation.Y += vector2.Y;
    }

    public float GetExtraHeightOffset() => (float) ((double) this.screenHeading.header.VScale.Y * (double) Sengine.ScreenRatioUpwardsMultiplier.Y * 0.5);

    public Vector2 GetSize(bool includeHeaderOnTop = true)
    {
      Vector2 vsCale = this.frame.VSCale;
      if (includeHeaderOnTop)
        vsCale.Y += this.GetExtraHeightOffset();
      return vsCale;
    }

    public bool UpdateNewThingTextBox(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      return this.textButton.UpdateTextButton(player, offset, DeltaTime);
    }

    public void DrawNewThingTextBox(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.frame.DrawCustomerFrame(offset, spriteBatch);
      this.screenHeading.DrawScreenHeading(offset, spriteBatch);
      this.para.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      this.smallPara.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      this.textButton.DrawTextButton(offset, 1f, spriteBatch);
    }
  }
}
