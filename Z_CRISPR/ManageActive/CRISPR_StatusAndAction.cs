// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_CRISPR.ManageActive.CRISPR_StatusAndAction
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using System;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir.CRISPR;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_CRISPR.ManageActive
{
  internal class CRISPR_StatusAndAction
  {
    public Vector2 location;
    private TextButton stopButton;
    private TextButton sellButton;
    private TextButton putInPenButton;
    private SimpleTextHandler statusText;
    private float totalHeight;
    private AnimalInFrame animalPreview;
    private CustomerFrame customerFrame;
    private MiniHeading miniHeading;
    private bool HasSellButton;

    public CRISPR_StatusAndAction(CrisprActiveBreed breed, float BaseScale, float forceWidth)
    {
      float num1 = 10f * BaseScale * Sengine.ScreenRatioUpwardsMultiplier.Y;
      this.totalHeight = 0.0f;
      this.totalHeight += num1;
      float num2 = 20f * BaseScale;
      Vector2 vector2_1 = new Vector2(10f, 10f);
      int num3 = breed.IsBorn_CanCollect ? 1 : 0;
      this.miniHeading = new MiniHeading(Vector2.Zero, "CRISPR Progress", 1f, BaseScale);
      this.totalHeight += this.miniHeading.GetTextHeight() * Sengine.ScreenRatioUpwardsMultiplier.Y;
      this.totalHeight += vector2_1.Y * BaseScale * Sengine.ScreenRatioUpwardsMultiplier.Y;
      if (num3 == 0)
      {
        this.stopButton = new TextButton(BaseScale, "Stop", 50f, _OverrideFrameScale: BaseScale);
        this.stopButton.SetButtonColour(BTNColour.Red);
        this.stopButton.vLocation.Y = this.totalHeight;
        this.stopButton.vLocation.Y += this.stopButton.GetSize().Y * 0.5f;
        this.totalHeight += this.stopButton.GetSize().Y;
        this.totalHeight += num1;
      }
      else
      {
        this.animalPreview = new AnimalInFrame(breed.resultBody, breed.resultHead, breed.resultBodyVariant, 50f * BaseScale, BaseScale: (BaseScale * 2f), HeadVariant: breed.resultHeadVariant);
        this.animalPreview.Location.Y = this.totalHeight;
        this.animalPreview.Location.X -= num2 + this.animalPreview.GetSize().X * 0.5f;
        this.animalPreview.Location.Y += this.animalPreview.GetSize().Y * 0.5f;
        this.totalHeight += this.animalPreview.GetSize().Y;
        if (this.HasSellButton)
          throw new Exception("TODO fix layout");
        this.putInPenButton = new TextButton(BaseScale, "Collect", 50f, _OverrideFrameScale: BaseScale);
        this.putInPenButton.vLocation.Y = this.animalPreview.Location.Y;
        this.putInPenButton.vLocation.X += (float) ((double) num2 * 0.5 + (double) this.putInPenButton.GetSize().X * 0.5);
        this.totalHeight += num1;
      }
      string empty = string.Empty;
      this.statusText = new SimpleTextHandler(num3 != 0 ? "Your new animal is ready!" : "Your animal is being grown, you may stop the process anytime.", true, (float) ((double) forceWidth / 1024.0 * 0.899999976158142), BaseScale);
      this.statusText.SetAllColours(ColourData.Z_Cream);
      this.statusText.Location.Y = this.totalHeight + this.statusText.GetHeightOfOneLine() * 0.5f;
      this.statusText.AutoCompleteParagraph();
      this.totalHeight += this.statusText.GetHeightOfParagraph();
      this.totalHeight += num1;
      this.customerFrame = new CustomerFrame(new Vector2(forceWidth, this.totalHeight), BaseScale: BaseScale);
      this.miniHeading.SetTextPosition(this.customerFrame.VSCale, vector2_1.X, vector2_1.Y);
      Vector2 vector2_2 = new Vector2(0.0f, (float) (-(double) this.customerFrame.VSCale.Y * 0.5));
      if (this.stopButton != null)
      {
        TextButton stopButton = this.stopButton;
        stopButton.vLocation = stopButton.vLocation + vector2_2;
      }
      if (this.sellButton != null)
      {
        TextButton sellButton = this.sellButton;
        sellButton.vLocation = sellButton.vLocation + vector2_2;
      }
      if (this.putInPenButton != null)
      {
        TextButton putInPenButton = this.putInPenButton;
        putInPenButton.vLocation = putInPenButton.vLocation + vector2_2;
      }
      if (this.animalPreview != null)
        this.animalPreview.Location += vector2_2;
      this.statusText.Location += vector2_2;
    }

    public float GetHeight() => this.customerFrame.VSCale.Y;

    public bool UpdateCRISPR_StatusAndAction(
      Player player,
      float DeltaTime,
      Vector2 offset,
      out bool throwBabyOut,
      out bool isSell,
      out bool isPutInPen)
    {
      offset += this.location;
      throwBabyOut = false;
      isSell = false;
      isPutInPen = false;
      if (this.stopButton != null && this.stopButton.UpdateTextButton(player, offset, DeltaTime))
      {
        throwBabyOut = true;
        return true;
      }
      if (this.sellButton != null && this.sellButton.UpdateTextButton(player, offset, DeltaTime))
      {
        isSell = true;
        return true;
      }
      if (this.putInPenButton == null || !this.putInPenButton.UpdateTextButton(player, offset, DeltaTime))
        return false;
      isPutInPen = true;
      return true;
    }

    public void DrawCRISPR_StatusAndAction(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.miniHeading.DrawMiniHeading(offset, spriteBatch);
      this.statusText.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      if (this.stopButton != null)
        this.stopButton.DrawTextButton(offset, 1f, spriteBatch);
      if (this.sellButton != null)
        this.sellButton.DrawTextButton(offset, 1f, spriteBatch);
      if (this.putInPenButton != null)
        this.putInPenButton.DrawTextButton(offset, 1f, spriteBatch);
      if (this.animalPreview == null)
        return;
      this.animalPreview.DrawAnimalInFrame(offset, spriteBatch);
    }
  }
}
