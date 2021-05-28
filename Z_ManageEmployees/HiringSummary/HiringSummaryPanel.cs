// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringSummary.HiringSummaryPanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_ManageShop.Shop_Data;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_ManageEmployees.HiringSummary
{
  internal class HiringSummaryPanel
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private MiniHeading miniHeading;
    private List<HiringQuickInfoFrame> infoFrames;
    private SimpleTextHandler maxCapacityText;

    public HiringSummaryPanel(
      ShopEntry shopEntry,
      OpenPositions currentOpenPositions,
      Player player,
      float forceWidth,
      float BaseScale,
      EmployeeType _RoamingEmployeeType = EmployeeType.Count)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      Vector2 vector2_1 = Vector2.One * 10f;
      float num1 = 0.0f;
      int num2 = _RoamingEmployeeType == EmployeeType.Count ? player.employees.GetEmployeesInThisSpecificShop(shopEntry.ShopUID).Count : player.employees.GetEmployeesOfThisType(_RoamingEmployeeType).Count;
      int num3 = -1;
      if (shopEntry != null)
        num3 = ShopData.GetMaximumEmployeesForThisShop(shopEntry.tiletype, player);
      string text = "Recruitment";
      if (num3 != -1)
        text = "Recruitment: " + (object) num2 + "/" + (object) num3;
      this.miniHeading = new MiniHeading(Vector2.Zero, text, 1f, BaseScale);
      float num4 = num1 + (this.miniHeading.GetTextHeight(true) + uiScaleHelper.ScaleY(vector2_1.Y)) + defaultYbuffer;
      float num5;
      if (num3 != -1 && num2 >= num3)
      {
        this.maxCapacityText = new SimpleTextHandler("You are currently at max capacity!", true, (float) ((double) forceWidth / 1024.0 * 0.899999976158142), BaseScale);
        this.maxCapacityText.AutoCompleteParagraph();
        this.maxCapacityText.SetAllColours(ColourData.Z_Cream);
        this.maxCapacityText.Location.Y = num4;
        num5 = num4 + this.maxCapacityText.GetHeightOfParagraph();
      }
      else
      {
        this.infoFrames = new List<HiringQuickInfoFrame>();
        float ForceHeight = -1f;
        float ForceWidth = forceWidth - defaultXbuffer * 2f;
        for (int index = 0; index < 3; ++index)
        {
          HiringQuickInfoFrame hiringQuickInfoFrame = new HiringQuickInfoFrame((RecruitmentInfoType) index, currentOpenPositions, BaseScale, ForceHeight, ForceWidth);
          hiringQuickInfoFrame.location.Y = num4;
          hiringQuickInfoFrame.location.Y += hiringQuickInfoFrame.GetSize().Y * 0.5f;
          num4 += hiringQuickInfoFrame.GetSize().Y;
          if (index != 2)
            num4 += defaultYbuffer;
          this.infoFrames.Add(hiringQuickInfoFrame);
        }
        num5 = num4 + ForceHeight;
      }
      float y = num5 + defaultYbuffer;
      this.customerFrame = new CustomerFrame(new Vector2(forceWidth, y), true, BaseScale);
      this.miniHeading.SetTextPosition(this.customerFrame.VSCale, vector2_1.X, vector2_1.Y);
      Vector2 vector2_2 = -this.customerFrame.VSCale * 0.5f;
      if (this.infoFrames != null)
      {
        for (int index = 0; index < this.infoFrames.Count; ++index)
          this.infoFrames[index].location.Y += vector2_2.Y;
      }
      if (this.maxCapacityText == null)
        return;
      this.maxCapacityText.Location.Y += vector2_2.Y;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public RecruitmentButtonType UpdateHiringSummaryPanel(
      Player player,
      float DeltaTime,
      Vector2 offset)
    {
      offset += this.location;
      if (this.infoFrames != null)
      {
        for (int index = 0; index < this.infoFrames.Count; ++index)
        {
          RecruitmentButtonType recruitmentButtonType = this.infoFrames[index].UpdateHiringQuickInfoFrame(player, DeltaTime, offset);
          if (recruitmentButtonType != RecruitmentButtonType.Count)
            return recruitmentButtonType;
        }
      }
      return RecruitmentButtonType.Count;
    }

    public void DrawHiringSummaryPanel(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.miniHeading.DrawMiniHeading(offset, spriteBatch);
      if (this.infoFrames != null)
      {
        for (int index = 0; index < this.infoFrames.Count; ++index)
          this.infoFrames[index].DrawHiringQuickInfoFrame(offset, spriteBatch);
      }
      if (this.maxCapacityText == null)
        return;
      this.maxCapacityText.DrawSimpleTextHandler(offset, 1f, spriteBatch);
    }
  }
}
