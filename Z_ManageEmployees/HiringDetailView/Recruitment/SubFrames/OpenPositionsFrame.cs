// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames.OpenPositionsFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Z_BalanceSystems.Employees;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_Manage.Hiring.Interview.Negotiation.MakeOffer;
using TinyZoo.Z_ManageEmployees.ManageEmployeeMain.HiringSummary;
using TinyZoo.Z_ManageShop.Shop_Data;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames
{
  internal class OpenPositionsFrame
  {
    public Vector2 location;
    private MiniHeading miniHeading;
    private CustomerFrame customerFrame;
    private SimpleTextHandler text;
    private PriceAdjuster openPositionsAdjuster;
    private OpenPositions TEMPOPENPOSITIONS;
    private bool AllowOpenPositionsToggling;
    private SpinningProgressIconWithText inProgressText;
    private bool IsActivelySearching;

    public OpenPositionsFrame(
      OpenPositions _TEMPOPENPOSITIONS,
      float forceWidth,
      float BaseScale,
      ShopEntry shopEntry,
      Player player)
    {
      this.TEMPOPENPOSITIONS = _TEMPOPENPOSITIONS;
      int ofPositionsOpened = this.TEMPOPENPOSITIONS.NumberOfPositionsOpened;
      this.AllowOpenPositionsToggling = _TEMPOPENPOSITIONS.GetNumberOfApplicants() == 0;
      this.IsActivelySearching = ofPositionsOpened > 0;
      int Max = JobApplicants_Calculator.GetMaximumOpenPositionsYouCanHave();
      if (ManageEmployeeManager.LimitOverHiring && shopEntry != null)
        Max = Math.Max(ShopData.GetMaximumEmployeesForThisShop(shopEntry.tiletype, player) - shopEntry.GetEmplyeeCount(), 0);
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      Vector2 vector2_1 = Vector2.One * 10f;
      float num1 = 0.0f;
      float num2 = 0.0f;
      this.miniHeading = new MiniHeading(Vector2.Zero, "Open Job Positions", 1f, BaseScale);
      float num3 = num1 + (float) ((double) this.miniHeading.GetTextHeight(true) + (double) uiScaleHelper.ScaleY(vector2_1.Y) + (double) defaultYbuffer * 0.5);
      float num4 = num2 + uiScaleHelper.ScaleX(vector2_1.X);
      string str = string.Empty;
      if (ManageEmployeeManager.LimitOverHiring && shopEntry != null)
        str = str + "Available Capacity: " + (object) Max + "~";
      string TextToWrite = str + "Open positions to allow applicants to apply for the job.";
      if (!this.AllowOpenPositionsToggling)
        TextToWrite = "You must respond to your current applicants before changing the job positions.";
      this.text = new SimpleTextHandler(TextToWrite, forceWidth * 0.6f, _Scale: BaseScale);
      float heightOfParagraph = this.text.GetHeightOfParagraph();
      this.text.AutoCompleteParagraph();
      this.text.Location.X = num4;
      this.text.Location.Y = num3;
      this.text.SetAllColours(ColourData.Z_Cream);
      float y = num3 + heightOfParagraph + defaultYbuffer;
      this.openPositionsAdjuster = new PriceAdjuster(0, Max, ofPositionsOpened, _BaseScale: BaseScale);
      this.openPositionsAdjuster.SetToString(ofPositionsOpened.ToString(), 40f, true);
      Vector2 size = this.openPositionsAdjuster.GetSize();
      this.openPositionsAdjuster.Location.X = forceWidth - defaultXbuffer;
      this.openPositionsAdjuster.Location.X -= size.X * 0.5f;
      this.openPositionsAdjuster.Location.Y = y;
      this.openPositionsAdjuster.Location.Y -= size.Y * 0.5f;
      this.openPositionsAdjuster.Location.Y -= defaultYbuffer;
      this.inProgressText = new SpinningProgressIconWithText(BaseScale, "Searching");
      if (this.text.paragraph.linemaker.GetNumberOfLines() > 2)
        this.inProgressText.location.Y += defaultYbuffer;
      else
        this.inProgressText.location.Y += uiScaleHelper.ScaleY(4f);
      this.inProgressText.location.Y += this.inProgressText.GetSize().Y * 0.5f;
      this.inProgressText.location.X = this.openPositionsAdjuster.Location.X;
      this.inProgressText.location.X -= this.inProgressText.GetSize().X * 0.5f;
      this.inProgressText.location.X -= uiScaleHelper.ScaleX(2f);
      if (!this.AllowOpenPositionsToggling)
        this.openPositionsAdjuster.SetDisabled(true);
      this.customerFrame = new CustomerFrame(new Vector2(forceWidth, y), BaseScale: BaseScale);
      this.miniHeading.SetTextPosition(this.customerFrame.VSCale, vector2_1.X, vector2_1.Y);
      Vector2 vector2_2 = -this.customerFrame.VSCale * 0.5f;
      this.text.Location += vector2_2;
      this.openPositionsAdjuster.Location += vector2_2;
      this.inProgressText.location += vector2_2;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public bool UpdateOpenPositionsFrame(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      if (this.openPositionsAdjuster.UpdatePriceAdjuster(player, offset, DeltaTime))
      {
        int currentValue = this.openPositionsAdjuster.CurrentValue;
        this.openPositionsAdjuster.SetToString(currentValue.ToString(), -1f);
        this.TEMPOPENPOSITIONS.NumberOfPositionsOpened = currentValue;
        this.IsActivelySearching = currentValue > 0;
        return true;
      }
      this.inProgressText.UpdateSpinningProgressIconWithText(DeltaTime);
      return false;
    }

    public void DrawOpenPositionsFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.miniHeading.DrawMiniHeading(offset, spriteBatch);
      this.text.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      this.openPositionsAdjuster.DrawPriceAdjuster(offset, spriteBatch);
      if (!this.IsActivelySearching)
        return;
      this.inProgressText.DrawSpinningProgressIconWithText(offset, spriteBatch);
    }
  }
}
